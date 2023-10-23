import { useState } from "react";
import PropTypes from "prop-types";

export default function Create({ onCreateSubmit }) {
    const [data, setData] = useState({
        title: "",
        category: "",
        maxLevel: "",
        imageUrl: "",
        summary: "",
    });

    const onChangeHandler = (e) => {
        setData((state) => ({ ...state, [e.target.name]: e.target.value }));
    };

    const onSubmit = (e) => {
        e.preventDefault();
        onCreateSubmit(data);
    };

    return (
        <section id="create-page" className="auth">
            <form id="create" onSubmit={onSubmit}>
                <div className="container">
                    <h1>Create Game</h1>
                    <label htmlFor="leg-title">Legendary title:</label>
                    <input
                        value={data.title}
                        onChange={onChangeHandler}
                        type="text"
                        id="title"
                        name="title"
                        placeholder="Enter game title..."
                    />

                    <label htmlFor="category">Category:</label>
                    <input
                        value={data.category}
                        onChange={onChangeHandler}
                        type="text"
                        id="category"
                        name="category"
                        placeholder="Enter game category..."
                    />

                    <label htmlFor="levels">MaxLevel:</label>
                    <input
                        value={data.maxLevel}
                        onChange={onChangeHandler}
                        type="number"
                        id="maxLevel"
                        name="maxLevel"
                        min="1"
                        placeholder="1"
                    />

                    <label htmlFor="game-img">Image:</label>
                    <input
                        value={data.imageUrl}
                        onChange={onChangeHandler}
                        type="text"
                        id="imageUrl"
                        name="imageUrl"
                        placeholder="Upload a photo..."
                    />

                    <label htmlFor="summary">Summary:</label>
                    <textarea
                        value={data.summary}
                        onChange={onChangeHandler}
                        name="summary"
                        id="summary"
                    ></textarea>
                    <input
                        className="btn submit"
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
