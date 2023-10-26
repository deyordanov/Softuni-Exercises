import "./App.css";

import { useForm } from "react-hook-form";

export default function App() {
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    console.log(data);
  }; // your form submit function which will invoke after successful validation

  console.log(watch("test")); // you can watch individual input by pass the name of the input

  return (
    <form
      className="flex flex-col gap-3 mt-10 justify-center w-[50%] h-screen"
      onSubmit={handleSubmit(onSubmit)}
    >
      {/* register your input into the hook by invoking the "register" function */}
      <input
        {...register("test", {
          minLength: {
            value: 3,
            message: "Username cannot be less than 3 characters long!",
          },
        })}
      />
      {errors.test && <p className="text-xs">{errors.test.message}</p>}

      {/* include validation with required or other standard HTML validation rules */}
      <input {...register("exampleRequired", { required: true })} />
      {/* errors will return when field validation fails  */}
      {errors.exampleRequired && (
        <p className="text-xs">This field is required</p>
      )}

      <input className="text-red-500" type="submit" />
    </form>
  );
}
