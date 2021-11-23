import React, { useRef } from "react";

interface TodoFormProps {
  onAdd(title: string): void;
}

export const TodoForm: React.FC<TodoFormProps> = (props) => {
  //   const [title, setTitle] = useState<string>("");

  const ref = useRef<HTMLInputElement>(null);

  //   const changeHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
  //     setTitle(event.target.value);
  //   };

  const keyPressHandler = (event: React.KeyboardEvent) => {
    if (event.key === "Enter") {
      props.onAdd(ref.current!.value);
      //   console.log();
      ref.current!.value = "";
      // console.log(title);
      // setTitle('');
    }
  };

  return (
    <div className="form-floating mt-2 mb-3">
      <input
        ref={ref}
        // onChange={changeHandler}
        // value={title}
        className="form-control form-control-sm"
        type="text"
        id="title"
        placeholder="Name"
        onKeyPress={keyPressHandler}
      ></input>
      <label htmlFor="title">Name</label>
    </div>
  );
};
