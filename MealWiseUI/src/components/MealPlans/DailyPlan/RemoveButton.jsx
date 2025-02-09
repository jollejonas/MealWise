import PropTypes from 'prop-types';

function removeButton({ onClick }) {
  return (
    <button onClick={onClick} className="btn btn-sm btn-danger">
        x
    </button>
  );
}

removeButton.protoTypes = {
    onClick: PropTypes.func.isRequired,
};

export default removeButton;