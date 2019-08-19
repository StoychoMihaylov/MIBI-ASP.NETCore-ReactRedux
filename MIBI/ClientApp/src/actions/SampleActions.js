import {
    REQUEST_ADD_NEW_SAMPLE,
    REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    REQUEST_ADD_NEW_SAMPLE_FAIL
} from '../constants/actionTypes'
import { api } from '../constants/api'

export function addNewSampleInTheServer(newSample) {
    console.log(newSample)
    return function (dispatch) {
        dispatch(createSample()) // Dispatch createNewSample

        return fetch(api + 'api/sample', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                "Accept": "application/json"
            },
            body: JSON.stringify(newSample)
            })
            .then(json => {
                console.log("SUCCESSFUL RESPONSE:")
                console.log(json)

                dispatch(createSampleSuccess()) // Dispatch Successful created sample
            })
            .catch(err => {
                console.log("ERROR:")
                console.log(err)

                dispatch(createSampleFail(true)) // Dispatch for error
            })
    }
}

export function createSample() {
    return {
        type: REQUEST_ADD_NEW_SAMPLE
    }
}

export function createSampleSuccess() {
    return {
        type: REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    }
}

export function createSampleFail(error) {
    return {
        type: REQUEST_ADD_NEW_SAMPLE_FAIL,
        payload: error
    }
}