import { Container, Form, Button } from 'react-bootstrap';
import { DndContext } from '@dnd-kit/core';
import { useState } from 'react';
import { useQuery } from '@tanstack/react-query';
import DailyPlan from '../components/MealPlans/DailyPlan/DailyPlan';
import DraggableRecipe from '../components/MealPlans/DraggableRecipe/DraggableRecipe';
import axios from 'axios';
import { format, addDays, parseISO, isValid, parse } from 'date-fns';

// Funktion til at vise dato i dansk format (dd-MM-yyyy)
const formatToDanishDate = (date) => format(date, 'dd-MM-yyyy');

    const mealTypeEnum = {
        breakfast: 0,
        lunch: 1,
        dinner: 2,
        snack: 3,
    };

// Hent opskrifter fra API
const fetchRecipes = async () => {
    const response = await axios.get('https://localhost:7104/api/recipes');
    console.log('API response:', response.data);

    const recipes = response.data || response.data;
    return recipes.map((recipe) => ({
        ...recipe,
        id: Number(recipe.id),
    }));
};

function CreateMealPlan() {
    const [startDate, setStartDate] = useState(format(new Date(), 'yyyy-MM-dd')); // Intern format
    const [mealPlan, setMealPlan] = useState({
        name: "",
        startDate: format(new Date(), 'yyyy-MM-dd'), // Intern format
        endDate: format(addDays(new Date(), 6), 'yyyy-MM-dd'), // Intern format
        mealPlanRecipes: [],
    });

    const { data, isLoading, error } = useQuery({
        queryKey: ['recipes'],
        queryFn: fetchRecipes,
    });

    // Opdater madplan når startdato ændres
    const handleDateChange = (event) => {
        const newDate = parse(event.target.value, 'yyyy-MM-dd', new Date());
        if (!isValid(newDate)) {
            console.error('Invalid date selected:', event.target.value);
            return;
        }

        const formattedDate = format(newDate, 'yyyy-MM-dd');
        const formattedEndDate = format(addDays(newDate, 6), 'yyyy-MM-dd');
        
        setStartDate(newDate);
        setMealPlan((prev) => ({
            ...prev,
            startDate: formattedDate,
            endDate: formattedEndDate,
        }));
    }

    // Håndter drag-and-drop
    const handleDragEnd = (event) => {
        const { active, over } = event;
        if (!over) return;
    
        console.log("Drag ended:", { activeId: active.id, overId: over.id });
    
        const parts = over.id.split('-');

        if (parts.length < 4) {
            console.error("Uventent over.id format", over.id);
            return;
        }

        const displayDate = parts.slice(0, 3).join('-');
        const mealType = parts[3];
        const recipeId = parseInt(active.id.split('-')[1], 10);

        const date = format(parse(displayDate, 'dd-MM-yyyy', new Date()), 'yyyy-MM-dd');
        console.log(displayDate, date, mealType);
        
        setMealPlan((prev) => ({
            ...prev,
            mealPlanRecipes: [
                ...prev.mealPlanRecipes,
                {
                    date,
                    mealType,
                    recipeId,
                    servingsOverride: 1,
                },
            ],
        }));
    };
    // Gem madplan til API
    const handleSaveMealPlan = async () => {
        const endDate = format(addDays(parseISO(startDate), 6), 'yyyy-MM-dd');

        try {
            const response = await axios.post('https://localhost:7104/api/mealplans', {
                mealPlanId: mealPlan.id,
                name: mealPlan.name || `Meal plan ${formatToDanishDate(parseISO(startDate))} - ${formatToDanishDate(parseISO(endDate))}`,
                startDate: mealPlan.startDate,
                endDate: mealPlan.endDate,
                mealPlanRecipes: mealPlan.mealPlanRecipes.map((meal) => ({
                    mealPlanId: mealPlan.id,
                    date: meal.date,
                    mealType: mealTypeEnum[meal.mealType],
                    recipeId: meal.recipeId,
                    servingsOverride: meal.servingsOverride,
                })),
            });
            console.log('Meal plan saved:', response.data);
        } catch (error) {
            console.error('Failed to save meal plan:', error);
        }
    };

    if (isLoading) return <p>Loading...</p>;
    if (error) return <p>Something went wrong: {error.message}</p>;

    return (
        <Container>
            <div>
                <h4>Vælg startdato:</h4>
                <Form.Control type="date" value={format(startDate, "yyyy-MM-dd")} onChange={handleDateChange} />
            </div>

            <DndContext onDragEnd={handleDragEnd}>
                <div style={{ display: 'flex' }}>
                    {/* Favoritopskrifter */}
                    <div style={{ width: '200px', marginRight: '20px' }}>
                        <h3>Favoritter</h3>
                        {data?.map((recipe) => (
                            <DraggableRecipe key={recipe.id} recipeId={recipe.id} name={recipe.title} />
                        ))}
                    </div>

                    {/* Madplan Grid */}
                    <div style={{ flexGrow: 1, display: 'grid', gridTemplateColumns: 'repeat(7, 1fr)', gap: '10px' }}>
                        {Array.from({ length: 7 }, (_, i) => {
                            const date = format(addDays(
                                typeof startDate === 'string' ? parseISO(startDate) : startDate, 
                                i
                            ), 'yyyy-MM-dd');
                            const displayDate = formatToDanishDate(parseISO(date));

                            return (
                            <DailyPlan 
                            key={date} 
                            day={displayDate}
                            mealPlanRecipes={mealPlan.mealPlanRecipes.filter(m => m.date === date)} 
                            recipes={data || []} 
                            />
                        );
                        })}

                    </div>
                </div>
            </DndContext>

            <Button onClick={handleSaveMealPlan}>Gem måltidsplan</Button>
        </Container>
    );
}

export default CreateMealPlan;
