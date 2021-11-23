import React from "react";
import { ITodo } from "../interfaces";

type TodoListProps = {
  todos: ITodo[];
  onToggle(id: number): void;
  onRemove: (id: number) => void;
};

export const TodoList: React.FC<TodoListProps> = ({ todos, onRemove, onToggle }) => {
  const removeHandler = (event: React.MouseEvent, id: number) => {
    event.preventDefault();
    onRemove(id);
  };

  if (todos.length === 0) {
    return <p className="text-center">No todos.</p>;
  }

  return (
    <ul>
      {todos.map((todo: ITodo) => {
        const classes = ["todo d-flex align-items-center"];

        if (todo.completed) {
          classes.push("completed");
        }

        return (
          <li className={classes.join(" ")} key={todo.id}>
            <input className="align-items-center" checked={todo.completed} type="checkbox" onChange={onToggle.bind(null, todo.id)} />
            <div className="ms-2">{todo.title}</div>
            <i className="ms-auto text-danger" onClick={(event) => removeHandler(event, todo.id)}>
              &times;
            </i>
          </li>
        );
      })}
    </ul>
  );
};
