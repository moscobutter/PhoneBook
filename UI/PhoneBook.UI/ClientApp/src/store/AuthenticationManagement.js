import { AuthenticationAPI } from '../api/';

const handleInputChange = 'HANDLE_INPUT_CHANGE';

const loginRequest = "LOGIN_REQUEST";
const loginResponse = "LOGIN_RESPONSE";

const showErrorMessage = "SHOW_ERROR_MESSAGE";
const closeErrorMessage = "CLOSE_ERROR_MESSAGE";
const initialState =
{
    isLoading: false,
    hasError: false,
    errorMessage:"",
    login: {
        username: "",
        password: "",
        rememberMe: false
    },
    loginResponse: {}
};

export const actionCreators = {
    loginAsync: () => async(dispatch, getState) => {

        let currState = getState().authenticationmanager;

        if (currState.isLoading == true) {
            return;
        }

        try {
            dispatch({ type: loginRequest });

            let login = { ...currState.login };

            let response = await AuthenticationAPI.loginAsync(login);


            var re = response;
            if (response.ok) {
                let data = await response.json();

                //dispatch({ type: loginResponse, loginResponse: data });

                var t = data;

            } else {
                dispatch({type:showErrorMessage, errorMessage: `Error: ${response.status} - ${response.statusText}`});
                return;
            }
        }
        catch (ex) {

        }
    },

    handleInputChange: (e) => async (dispatch, getState) => {
        dispatch({ type: handleInputChange, input: e });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === handleInputChange) {
        let login = { ...state.login };

        login[action.input.target.name] = action.input.target.value;

        return {
            ...state,
            login: {...login}
        };
    }

    if (action.type === loginRequest) {
        return { state };
    }

    if (action.type === loginResponse) {
        return { state };
    }

    if (action.type === showErrorMessage) {
        return { state };
    }

    if (action.type === closeErrorMessage) {
        return { state };
    }

    return state;
};
