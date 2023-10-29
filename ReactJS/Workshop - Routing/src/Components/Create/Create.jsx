import PropTypes from "prop-types";
import { useForm } from "react-hook-form";

import { CreateGameFormKeys } from "../../utilities/constans";
import ErrorMessage from "../../utilities/ErrorMessage";

export default function Create({ onCreateSubmit }) {
    const {
        register,
        handleSubmit,
        formState: { errors },
        watch,
        setValue,
    } = useForm({
        defaultValues: {
            [CreateGameFormKeys.TITLE]: "",
            [CreateGameFormKeys.GENRES]: "",
            [CreateGameFormKeys.MAX_LEVEL]: "",
            [CreateGameFormKeys.IMAGE_URL]: null,
            [CreateGameFormKeys.DESCRIPTION]: "",
        },
        mode: "onChange",
    });

    const onSubmit = (data) => {
        const file = data[CreateGameFormKeys.IMAGE_URL][0];
        const url = URL.createObjectURL(file);
        onCreateSubmit({ ...data, [CreateGameFormKeys.IMAGE_URL]: url });
    };

    const selectedFile = watch(CreateGameFormKeys.IMAGE_URL);

    const onImageExit = () => {
        setValue(CreateGameFormKeys.IMAGE_URL, null);
    };
    return (
        <section
            id="create-page"
            className="auth bg-slate-800 shadow-2xl shadow-black w-[600px]"
        >
            <form id="create" onSubmit={handleSubmit(onSubmit)}>
                <div className="container w-[80%] flex flex-col items-center">
                    <h1>Create Game</h1>
                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="title">Title:</label>
                        <input
                            {...register(CreateGameFormKeys.TITLE, {
                                required: "This field is required!",
                                minLength: {
                                    value: 2,
                                    message:
                                        "The title can't be less than 2 characters long!",
                                },
                            })}
                            type="text"
                            id="title"
                            name="title"
                            placeholder="Enter game title..."
                        />
                        <ErrorMessage
                            errors={errors}
                            fieldKey={CreateGameFormKeys.TITLE}
                        />
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="genres">Genres:</label>
                        <input
                            {...register(CreateGameFormKeys.GENRES, {
                                required: "This field is required!",
                                minLength: {
                                    value: 4,
                                    message:
                                        "The genres can't be less than 4 characters long!",
                                },
                            })}
                            type="text"
                            id="genres"
                            name="genres"
                            placeholder="Enter game genres..."
                        />
                        <ErrorMessage
                            errors={errors}
                            fieldKey={CreateGameFormKeys.GENRES}
                        />
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="maxLevel">MaxLevel:</label>
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
                        <ErrorMessage
                            errors={errors}
                            fieldKey={CreateGameFormKeys.MAX_LEVEL}
                        />
                    </div>
                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="game-img">Image:</label>
                        {!selectedFile && ( // Conditionally render the file input
                            <input
                                {...register(CreateGameFormKeys.IMAGE_URL, {
                                    required: "This field is required!",
                                })}
                                type="file"
                                id="imageUrl"
                                name="imageUrl"
                                accept=".png, .jpg, .jpeg"
                            />
                        )}
                        {selectedFile && selectedFile.length > 0 && (
                            <div className="relative">
                                <img
                                    src={URL.createObjectURL(selectedFile[0])}
                                    alt="Preview"
                                    className="mb-4 max-w-[400px]"
                                />
                                <button
                                    onClick={onImageExit}
                                    className="absolute -top-1 right-1 text-red-500 text-2xl"
                                >
                                    X
                                </button>
                            </div>
                        )}
                        <ErrorMessage
                            errors={errors}
                            fieldKey={CreateGameFormKeys.IMAGE_URL}
                        />
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="description">Description:</label>
                        <textarea
                            {...register(CreateGameFormKeys.DESCRIPTION, {
                                required: "This field is required!",
                                minLength: {
                                    value: 10,
                                    message:
                                        "The description can't be less than 10 characters long!",
                                },
                            })}
                            name="description"
                            id="description"
                        ></textarea>
                        <ErrorMessage
                            errors={errors}
                            fieldKey={CreateGameFormKeys.DESCRIPTION}
                        />
                    </div>

                    <input
                        className="btn submit bg-slate-700 w-[50%] hover:shadow-lg hover:shadow-white"
                        type="submit"
                        value="Create Game"
                    />
                </div>
            </form>
        </section>
    );
}

Create.propTypes = {
    onCreateSubmit: PropTypes.func.isRequired,
};
