export const setToken = (token) => {
    localStorage.setItem("user", JSON.stringify(token));
}

export const getToken = () => {
    return JSON.parse(localStorage.getItem("user"));
}

export const getFullName = () => {
    let user = JSON.parse(localStorage.getItem("user"));

    if (user !== null) return JSON.parse(localStorage.getItem("user")).fullname;

    return "";
}

export const removeToken = () => {
    localStorage.removeItem("user");
}

export const isTokenSet = () => {
    return (localStorage.getItem("user") !== null);
}

export const getBearerToken = () => {
    if (localStorage.getItem("user") !== null) return JSON.parse(localStorage.getItem("user")).token;

    return "";
}