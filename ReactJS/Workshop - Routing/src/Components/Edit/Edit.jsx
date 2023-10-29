import PropTypes from "prop-types";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";

import * as gameService from "../../Services/gameService";
import { EditGameFormKeys } from "../../utilities/constans";
import ErrorMessage from "../../utilities/ErrorMessage";

export default function Edit({ onEditSubmit }) {
    const { gameId } = useParams();
    const [game, setGame] = useState({});
    const [selectedFileState, setSelectedFileState] = useState(null);
    const {
        register,
        handleSubmit,
        setValue,
        watch,
        formState: { errors },
    } = useForm({
        defaultValues: {
            [EditGameFormKeys.TITLE]: "",
            [EditGameFormKeys.GENRES]: "",
            [EditGameFormKeys.MAX_LEVEL]: "",
            [EditGameFormKeys.IMAGE_URL]: null,
            [EditGameFormKeys.DESCRIPTION]: "",
        },
        mode: "onChange",
    });

    const selectedFile = watch(EditGameFormKeys.IMAGE_URL);

    useEffect(() => {
        if (selectedFile && selectedFile.length > 0) {
            setSelectedFileState(selectedFile[0]);
        }
    }, [selectedFile]);

    //We need to set the default values this way, because when the component is rendered the 'game' object is empty
    useEffect(() => {
        for (let key in game) {
            setValue(key, game[key]);
        }
    }, [game, setValue]);

    useEffect(() => {
        gameService.getOne(gameId).then((response) => setGame(response));
    }, [gameId]);

    const onSubmit = (data, gameId) => {
        //We retrieve the file - if it exists => get data from data[EditGameFormKeys.IMAGE_URL][0], else it will be undefined
        const file =
            data[EditGameFormKeys.IMAGE_URL] &&
            data[EditGameFormKeys.IMAGE_URL][0];
        if (file instanceof File) {
            data[EditGameFormKeys.IMAGE_URL] = URL.createObjectURL(file);
        }
        onEditSubmit(data, gameId);
    };

    const onImageExit = () => {
        setValue(EditGameFormKeys.IMAGE_URL, null);
    };
    return (
        <section
            id="edit-page"
            className="auth bg-slate-800 flex items-center relative w-[600px] shadow-2xl shadow-black"
        >
            <form
                id="edit"
                onSubmit={handleSubmit((data) => onSubmit(data, gameId))}
            >
                <div className="container flex flex-col items-center w-[500px]">
                    <h1>Edit Game</h1>
                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="leg-title">Title:</label>
                        <input
                            {...register(EditGameFormKeys.TITLE, {
                                minLength: {
                                    value: 2,
                                    message:
                                        "The title can`t be less than 2 characaters long!",
                                },
                            })}
                            type="text"
                            id="title"
                            name="title"
                        />
                        <ErrorMessage
                            errors={errors}
                            fieldKey={EditGameFormKeys.TITLE}
                        />
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="genres">Genres:</label>
                        <input
                            {...register(EditGameFormKeys.GENRES, {
                                minLength: {
                                    value: 4,
                                    message:
                                        "The genres can`t be less than 4 characters long!",
                                },
                            })}
                            type="text"
                            id="genres"
                            name="genres"
                        />
                        <ErrorMessage
                            errors={errors}
                            fieldKey={EditGameFormKeys.GENRES}
                        />
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="levels">MaxLevel:</label>
                        <input
                            {...register(EditGameFormKeys.MAX_LEVEL, {})}
                            type="number"
                            id="maxLevel"
                            name="maxLevel"
                            min="1"
                        />
                        <ErrorMessage
                            errors={errors}
                            fieldKey={EditGameFormKeys.MAX_LEVEL}
                        />
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="game-img">Image:</label>
                        {selectedFile && selectedFile.length > 0 && (
                            <div className="relative">
                                {selectedFileState instanceof File ? (
                                    <img
                                        src={URL.createObjectURL(
                                            selectedFileState
                                        )}
                                        alt="New Game Image"
                                        className="mb-4 max-w-[400px]"
                                    />
                                ) : game.imageUrl ? (
                                    <img
                                        src={game.imageUrl}
                                        alt="Current Game"
                                        className="mb-4 max-w-[400px]"
                                    />
                                ) : null}

                                <button
                                    type="button"
                                    onClick={onImageExit}
                                    className="absolute -top-1 right-1 text-red-500 text-2xl"
                                >
                                    X
                                </button>
                            </div>
                        )}

                        {!selectedFile && (
                            <input
                                {...register(EditGameFormKeys.IMAGE_URL, {
                                    required: "This field is required!",
                                })}
                                type="file"
                                id="imageUrl"
                                name="imageUrl"
                                accept=".png, .jpg, .jpeg"
                            />
                        )}
                        <ErrorMessage
                            errors={errors}
                            fieldKey={EditGameFormKeys.IMAGE_URL}
                        />
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="description">Description:</label>
                        <textarea
                            {...register(EditGameFormKeys.DESCRIPTION, {
                                minLength: {
                                    value: 10,
                                    message:
                                        "The description can`t be less than 10 characters long!",
                                },
                            })}
                            name="description"
                            id="description"
                        ></textarea>
                        <ErrorMessage
                            errors={errors}
                            fieldKey={EditGameFormKeys.DESCRIPTION}
                        />
                    </div>

                    <input
                        className="btn submit bg-slate-700 w-[40%] hover:shadow-lg hover:shadow-white"
                        type="submit"
                        value="Edit"
                    />
                </div>
            </form>
        </section>
    );
}

Edit.propTypes = {
    onEditSubmit: PropTypes.func,
};
