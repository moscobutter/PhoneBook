const API_URL = "https://localhost:44360/api/";
export const PhoneBookAPI = {
    searchEntriesForPhoneBookAsync:  async(phoneBookId, searchText) => {
        return await fetch({
            url: `${API_URL}phonebook/${phoneBookId}/${searchText}`
        });
    },

    addEntryAsync : async (entryRequest) => {
        return await fetch({
            url: `${API_URL}/phonebook`,
            method: "POST",
            body: JSON.stringify(entryRequest)
        });
    }
}

export const AuthenticationAPI = {
    loginAsync : async (loginRequest) => {

        return await fetch({
            url: `${API_URL}authentication/login/`,
            method: "POST",
            body: JSON.stringify(loginRequest)
        });
    }
}