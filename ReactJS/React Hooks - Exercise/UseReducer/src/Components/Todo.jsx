import PropTypes from "prop-types";

export default function Todo({
  id,
  name,
  complete,
  handleToggle,
  handleDelete,
}) {
  return (
    <article>
      <h2>Task: {name}</h2>
      <p style={{ color: complete ? "lime" : "red" }}>
        <b>{complete ? "Complete" : "Incomplete"}</b>
      </p>
      <button onClick={() => handleToggle(id)}>Toggle</button>
      <button onClick={() => handleDelete(id)}>Delete</button>
    </article>
  );
}

Todo.propTypes = {
  id: PropTypes.number,
  name: PropTypes.string,
  complete: PropTypes.bool,
  handleToggle: PropTypes.func,
  handleDelete: PropTypes.func,
};
