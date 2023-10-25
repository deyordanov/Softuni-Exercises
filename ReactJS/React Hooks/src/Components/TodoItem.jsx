import { ListGroup, Button } from "react-bootstrap";
import PropTypes from "prop-types";

export default function TodoItem({
    _id,
    task,
    isCompleted,
    onTodoUpdate,
    onTodoDelete,
}) {
    const onChangeHandler = () => {
        onTodoUpdate({ _id, task, isCompleted: !isCompleted });
    };

    return (
        <>
            <ListGroup.Item
                className={`${
                    !isCompleted ? "focus:text-rose-500" : "text-green-500"
                } hover:bg-slate-100 text-xs h-10 flex items-center border-b-black border-b-2 last:border-b-0 justify-between`}
            >
                {task}
                <div>
                    {!isCompleted && (
                        <Button
                            onClick={onChangeHandler}
                            variant="primary"
                            size="sm"
                            className="p-1 text-xs ml-3 bg-green-500 border-none hover:bg-green-700"
                        >
                            Complete
                        </Button>
                    )}
                    <Button
                        onClick={() => onTodoDelete(_id)}
                        variant="primary"
                        size="sm"
                        className="p-1 text-xs ml-3 bg-red-600 border-none hover:bg-red-700"
                    >
                        Delete
                    </Button>
                </div>
            </ListGroup.Item>
        </>
    );
}

TodoItem.propTypes = {
    _id: PropTypes.string,
    task: PropTypes.string,
    isCompleted: PropTypes.bool,
    onTodoUpdate: PropTypes.func,
    onTodoDelete: PropTypes.func,
};
