import PropTypes from "prop-types";
import { useForm } from "react-hook-form";

import { CreateGameFormKeys } from "../../utilities/constans";

export default function Create({ onCreateSubmit }) {
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm({
        [CreateGameFormKeys.TITLE]: "",
        [CreateGameFormKeys.GENRES]: "",
        [CreateGameFormKeys.MAX_LEVEL]: "",
        [CreateGameFormKeys.IMAGE_URL]: "",
        [CreateGameFormKeys.DESCRIPTION]: "",
        mode: "onChange",
    });

    const onSubmit = (data) => {
        console.log(data);
        onCreateSubmit(data);
    };

    return (
        <section
            id="create-page"
            className="auth bg-slate-800 shadow-2xl shadow-black"
        >
            <form id="create" onSubmit={handleSubmit(onSubmit)}>
                <div className="container w-[80%] flex flex-col items-center">
                    <h1>Create Game</h1>
                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="leg-title">Title:</label>
                        <input
                            {...register(CreateGameFormKeys.TITLE, {
                                required: "This field is required!",
                                minLength: {
                                    value: 2,
                                    message:
                                        "The title can`t be less than 2 characaters long!",
                                },
                            })}
                            type="text"
                            id="title"
                            name="title"
                            placeholder="Enter game title..."
                        />
                        {errors[CreateGameFormKeys.TITLE] && (
                            <p className="mt-2 text-xl text-red-500">{`⚠ ${
                                errors[CreateGameFormKeys.TITLE].message
                            }`}</p>
                        )}
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="genres">Genres:</label>
                        <input
                            {...register(CreateGameFormKeys.GENRES, {
                                required: "This field is required!",
                                minLength: {
                                    value: 4,
                                    message:
                                        "The genres can`t be less than 4 characters long!",
                                },
                            })}
                            type="text"
                            id="genres"
                            name="genres"
                            placeholder="Enter game genres..."
                        />
                        {errors[CreateGameFormKeys.GENRES] && (
                            <p className="mt-2 text-xl text-red-500">{`⚠ ${
                                errors[CreateGameFormKeys.GENRES].message
                            }`}</p>
                        )}
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="levels">MaxLevel:</label>
                        <input
                            {...register(CreateGameFormKeys.MAX_LEVEL, {
                                required: "This field is required!",
                            })}
                            type="number"
                            id="maxLevel"
                            name="maxLevel"
                            min="1"
                            placeholder="1"
                        />
                        {errors[CreateGameFormKeys.MAX_LEVEL] && (
                            <p className="mt-2 text-xl text-red-500">{`⚠ ${
                                errors[CreateGameFormKeys.MAX_LEVEL].message
                            }`}</p>
                        )}
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="game-img">Image:</label>
                        <input
                            {...register(CreateGameFormKeys.IMAGE_URL, {
                                required: "This field is required!",
                            })}
                            type="text"
                            id="imageUrl"
                            name="imageUrl"
                            placeholder="Upload a photo..."
                        />
                        {errors[CreateGameFormKeys.IMAGE_URL] && (
                            <p className="mt-2 text-xl text-red-500">{`⚠ ${
                                errors[CreateGameFormKeys.IMAGE_URL].message
                            }`}</p>
                        )}
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="description">Description:</label>
                        <textarea
                            {...register(CreateGameFormKeys.DESCRIPTION, {
                                required: "This field is required!",
                                minLength: {
                                    value: 10,
                                    message:
                                        "The description can`t be less than 10 characters long!",
                                },
                            })}
                            name="description"
                            id="description"
                        ></textarea>
                        {errors[CreateGameFormKeys.DESCRIPTION] && (
                            <p className="mt-2 text-xl text-red-500">{`⚠ ${
                                errors[CreateGameFormKeys.DESCRIPTION].message
                            }`}</p>
                        )}
                    </div>

                    <input
                        className="btn submit bg-slate-700 w-[40%] hover:shadow-lg hover:shadow-white"
                        type="submit"
                        value="Create Game"
                    />
                </div>
            </form>
        </section>
    );
}

Create.propTypes = {
    onCreateSubmit: PropTypes.func,
};
