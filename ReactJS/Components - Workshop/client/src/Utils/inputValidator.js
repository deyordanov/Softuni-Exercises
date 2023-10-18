export default function ValidateInput(type, input) {
    const validations = {
        firstName: (value) => value.length < 3,
        lastName: (value) => value.length < 3,
        email: (value) =>
            !/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/.test(value),
        phoneNumber: (value) =>
            !/^(?:\+359|0)(?:[87][0-9]{8}|[2-9][0-9]{6,7})$/.test(value),
        imageUrl: (value) =>
            !/^(https?|ftp):\/\/[^\s/$.?#].[^\s]*$/.test(value),
        country: (value) => value.length < 2,
        city: (value) => value.length < 3,
        street: (value) => value.length < 3,
        streetNumber: (value) => value < 0,
    };

    return validations[type](input);
}
