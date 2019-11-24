import {
    REQUEST_REGISTER_NEW_ACCOUNT,
    REQUEST_REGISTER_NEW_ACCOUNT_SUCCESS,
    REQUEST_REGISTER_NEW_ACCOUNT_FAIL,
    REQUEST_ACCOUNT_LOGIN,
    REQUEST_ACCOUNT_LOGIN_SUCCESS,
    REQUEST_ACCOUNT_LOGIN_FAIL,
    REQUEST_ACCOUNT_LOGOUT,
    REQUEST_ACCOUNT_LOGOUT_SUCCESS,
    REQUEST_ACCOUNT_LOGOUT_FAIL
} from '../../constants/AccountActionTypes'
import { api } from '../../constants/api'
import axios from 'axios'

var qs = require('qs');

//*************************** Register account actions ***************************

export function registerAccount(userModel) {
    return dispatch => {
        dispatch(requestRegisterAccount())
        return axios.post(api + 'api/account/register', userModel)
        .then(response => {
            dispatch(requestRegisterAccountSuccess(response))
            return response
        })
        .catch(err => {
            dispatch(requestRegisterAccountFail(err))
            return err
        })
    }
}

export function requestRegisterAccount() {
    return {
        type: REQUEST_REGISTER_NEW_ACCOUNT
    }
}

export function requestRegisterAccountSuccess(data) {
    return {
        type: REQUEST_REGISTER_NEW_ACCOUNT_SUCCESS,
        payload: data
    }
}

export function requestRegisterAccountFail(error) {
    return {
        type: REQUEST_REGISTER_NEW_ACCOUNT_FAIL,
        payload: error
    }
}
