export default function formatDate(inputDate) {
    const options = {
        weekday: "long",
        year: "numeric",
        month: "long",
        day: "numeric",
    };

    const formattedDate = new Date(inputDate).toLocaleDateString(
        "en-US",
        options
    );

    return formattedDate;
}
