import PropTypes from "prop-types";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";

import * as gameService from "../../Services/gameService";
import { EditGameFormKeys } from "../../utilities/constans";

export default function Edit({ onEditSubmit }) {
    const { gameId } = useParams();
    const [game, setGame] = useState({});
    const {
        register,
        handleSubmit,
        setValue,
        formState: { errors },
    } = useForm({
        defaultValues: {
            [EditGameFormKeys.TITLE]: "",
            [EditGameFormKeys.GENRES]: "",
            [EditGameFormKeys.MAX_LEVEL]: "",
            [EditGameFormKeys.IMAGE_URL]: "",
            [EditGameFormKeys.DESCRIPTION]: "",
        },
        mode: "onChange",
    });

    //We need to set the default values this way, because when the component is rendered the 'game' object is empty
    useEffect(() => {
        for (let key in game) {
            setValue(key, game[key]);
        }
    }, [game, setValue]);

    useEffect(() => {
        gameService.getOne(gameId).then((response) => setGame(response));
    }, [gameId]);

    return (
        <section
            id="edit-page"
            className="auth bg-slate-800 flex items-center relative w-[600px] shadow-2xl shadow-black"
        >
            <form
                id="edit"
                onSubmit={handleSubmit((data) => onEditSubmit(data, gameId))}
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
                        {errors[EditGameFormKeys.TITLE] && (
                            <p className="mt-2 text-xl text-red-500">{`⚠ ${
                                errors[EditGameFormKeys.TITLE].message
                            }`}</p>
                        )}
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
                        {errors[EditGameFormKeys.GENRES] && (
                            <p className="mt-2 text-xl text-red-500">{`⚠ ${
                                errors[EditGameFormKeys.GENRES].message
                            }`}</p>
                        )}
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
                        {errors[EditGameFormKeys.MAX_LEVEL] && (
                            <p className="mt-2 text-xl text-red-500">{`⚠ ${
                                errors[EditGameFormKeys.MAX_LEVEL].message
                            }`}</p>
                        )}
                    </div>

                    <div className="w-full flex flex-col items-center">
                        <label htmlFor="game-img">Image:</label>
                        <input
                            {...register(EditGameFormKeys.IMAGE_URL, {})}
                            type="text"
                            id="imageUrl"
                            name="imageUrl"
                        />
                        {errors[EditGameFormKeys.IMAGE_URL] && (
                            <p className="mt-2 text-xl text-red-500">{`⚠ ${
                                errors[EditGameFormKeys.IMAGE_URL].message
                            }`}</p>
                        )}
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
                        {errors[EditGameFormKeys.DESCRIPTION] && (
                            <p className="mt-2 text-xl text-red-500">{`⚠ ${
                                errors[EditGameFormKeys.DESCRIPTION].message
                            }`}</p>
                        )}
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
