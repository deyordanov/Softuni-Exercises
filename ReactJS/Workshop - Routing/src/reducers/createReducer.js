import { DetailsActions } from "../utilities/constans";

export const createReducer = (state, action) => {
    switch (action.type) {
        case DetailsActions.SET_GAME:
            return { ...state, game: action.payload.game };
        case DetailsActions.SET_COMMENTS:
            return { ...state, comments: action.payload.comments };
        default:
            return state;
    }
};
