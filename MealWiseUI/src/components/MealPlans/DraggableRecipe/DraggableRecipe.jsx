

import { useDraggable } from "@dnd-kit/core";
import PropTypes from 'prop-types';

function DraggableRecipe({ recipeId, name }) {
    const { attributes, listeners, setNodeRef, transform} = useDraggable({
        id: `recipe-${recipeId}`
    });

    const style = {
        transform: transform ? `translate(${transform.x}px, ${transform.y}px)` : undefined,
        cursor: "grab",
        padding: "8px",
        border: "1px solid black",
        backgroundColor: "lightgrey",
        marginBottom: "5px",
    };

    return (
        <div ref={setNodeRef} style={style} {...listeners} {...attributes}>
            {name}
        </div>
    )
}
DraggableRecipe.propTypes = {
    recipeId: PropTypes.number.isRequired,
    name: PropTypes.string.isRequired,
};

export default DraggableRecipe;

