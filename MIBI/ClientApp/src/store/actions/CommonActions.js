import {
    SET_INFO_MESSAGE_BOX,
    SET_SUCCESSFUL_MESSAGE_BOX,
    SET_ERROR_MESSAGE_BOX,
    CLEAR_INFO_MESSAGE_BOX
} from '../../constants/CommonActionTypes'


//*************************** INFO BOX MESSAGE actions ***************************

export const setInfoMessageBox = message => {
    return function (dispatch) {
        dispatch(setInfoMessageBoxAction(message))

        setTimeout(() => {
            dispatch(clearInfoMessageBoxAction())
        }, 3000)
    }
}

export const setSuccessfulMessageBox = message => {
    return function (dispatch) {
        dispatch(setSuccessfulMessageBoxAction(message))

        setTimeout(() => {
            dispatch(clearInfoMessageBoxAction())
        }, 3000)
    }
}

export const setErrorMessageBox = message => {
    return function (dispatch) {
        dispatch(setErrorMessageBoxAction(message))

        setTimeout(() => {
            dispatch(clearInfoMessageBoxAction())
        }, 3000)
    }
}

export const clearInfoMessageBox = () => {
    return function (dispatch) {
        dispatch(clearInfoMessageBoxAction())
    }
}

export function setInfoMessageBoxAction(message) {
    return {
        type: SET_INFO_MESSAGE_BOX,
        message: message
    }
}

export function setSuccessfulMessageBoxAction(message) {
    return {
        type: SET_SUCCESSFUL_MESSAGE_BOX,
        message : message
    }
}

export function setErrorMessageBoxAction(message) {
    return {
        type: SET_ERROR_MESSAGE_BOX,
        message: message
    }
}

export function clearInfoMessageBoxAction() {
    return {
        type: CLEAR_INFO_MESSAGE_BOX
    }
}