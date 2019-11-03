import {
    SET_INFO_MESSAGE_BOX,
    SET_SUCCESSFUL_MESSAGE_BOX,
    SET_ERROR_MESSAGE_BOX,
    CLEAR_INFO_MESSAGE_BOX
} from '../../constants/CommonActionTypes'

const initialState = {
    infoMessage: "",
    successMessage: "",
    errorMessage: ""
}

const CommonReducer = (state, action) => {
    state = state || initialState

    switch (action.type) {
        case SET_INFO_MESSAGE_BOX:
            return {
                ...state,
                infoMessage: action.message
            }
        case SET_SUCCESSFUL_MESSAGE_BOX:
            return {
                ...state,
                successMessage: action.message
            }
        case SET_ERROR_MESSAGE_BOX:
            return {
                ...state,
                errorMessage: action.message
            }
        case CLEAR_INFO_MESSAGE_BOX:
            return {
                ...state,
                infoMessage: "",
                successMessage: "",
                errorMessage: ""
            }
            default:
                return state
    }
}

export default CommonReducer