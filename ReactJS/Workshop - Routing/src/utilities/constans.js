export const LoginOrRegisterFormKeys = {
    EMAIL: "email",
    PASSWORD: "password",
    PASSWORD_CONFIRMATION: "password_confirmation",
};

export const CreateGameFormKeys = {
    TITLE: "title",
    GENRES: "genres",
    MAX_LEVEL: "maxLevel",
    IMAGE_URL: "imageUrl",
    DESCRIPTION: "description",
};

export const EditGameFormKeys = {
    TITLE: "title",
    GENRES: "genres",
    MAX_LEVEL: "maxLevel",
    IMAGE_URL: "imageUrl",
    DESCRIPTION: "description",
};

export const LikeCommentActions = {
    ADD: "add",
    REMOVE: "remove",
};

export const CreateCommentFormKeys = {
    AUTHOR: "author",
    COMMENT: "comment",
};

/////////////////////////////// -> reducer action types
export const EditGameActions = {
    SET_GAME: "set_game",
};

export const DetailsActions = {
    SET_COMMENTS: "set_comments",
    SET_GAME: "set_game",
};

/////////////////////////////// -> useForm default values

export const defaultDetailsUseFormValues = {
    [CreateCommentFormKeys.AUTHOR]: "",
    [CreateCommentFormKeys.COMMENT]: "",
};

export const defaultCreateUseFormValues = {
    [CreateGameFormKeys.TITLE]: "",
    [CreateGameFormKeys.GENRES]: "",
    [CreateGameFormKeys.MAX_LEVEL]: "",
    [CreateGameFormKeys.IMAGE_URL]: null,
    [CreateGameFormKeys.DESCRIPTION]: "",
};

export const defaultEditUseFormValues = {
    [EditGameFormKeys.TITLE]: "",
    [EditGameFormKeys.GENRES]: "",
    [EditGameFormKeys.MAX_LEVEL]: "",
    [EditGameFormKeys.IMAGE_URL]: null,
    [EditGameFormKeys.DESCRIPTION]: "",
};

export const defaultLoginUserFormValues = {
    [LoginOrRegisterFormKeys.EMAIL]: "",
    [LoginOrRegisterFormKeys.PASSWORD]: "",
};

export const defaultRegisterFormValues = {
    [LoginOrRegisterFormKeys.EMAIL]: "",
    [LoginOrRegisterFormKeys.PASSWORD]: "",
    [LoginOrRegisterFormKeys.PASSWORD_CONFIRMATION]: "",
};

/////////////////////////////// -> initital reducer values
export const initialDetailsReducerValues = {
    comments: [],
    game: {},
};

export const initialEditReducerValues = {
    game: {},
};
