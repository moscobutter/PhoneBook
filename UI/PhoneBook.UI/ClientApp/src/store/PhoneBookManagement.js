const incrementCountType = 'INCREMENT_COUNT';
const decrementCountType = 'DECREMENT_COUNT';
const initialState =
{
    isLoading: false,
    currentScreen: "",
    screens: {
        "MAIN": "Main",
        "CONTACT": "ContactItem",
        "CONTACTLIST":"ContactList"
    },
    user: {},
    phoneBook: {},
    contactList: []
};

export const actionCreators = {
    increment: () => ({ type: incrementCountType }),
    decrement: () => ({ type: decrementCountType })
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === incrementCountType) {
        return { state };
    }

    if (action.type === decrementCountType) {
        return { state};
    }

    return state;
};
