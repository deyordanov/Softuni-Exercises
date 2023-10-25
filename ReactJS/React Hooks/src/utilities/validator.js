const VALUES = {
    TASK: "task",
};

export const Validate = (value, input) => {
    switch (value) {
        case VALUES.TASK:
            return input.length < 3;
    }
};
