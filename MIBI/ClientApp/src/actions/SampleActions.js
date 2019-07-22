import {
    REQUEST_ADD_NEW_SAMPLE,
    REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    REQUEST_ADD_NEW_SAMPLE_FAIL
} from '../constants/actionTypes'
import { api } from '../constants/api'

export function requestAddNewSample() {
    return (dispatch) => {
        dispatch(createSample())

        fetch(api + "addSample")
            .then(data => dispatch(createSample({
                type: REQUEST_ADD_NEW_SAMPLE,
                payload: data
            })))
            .then(resp => resp.json())
            .then(json => {
                console.log(json)

                dispatch(createSampleSuccess)
            })
            .catch(err => dispatch(createSampleFail(err)))
    }
}

export function createSample(payload) {
    return {
        type: REQUEST_ADD_NEW_SAMPLE,
        payload
    }
}

export function createSampleSuccess() {
    return {
        type: REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    }
}

export function createSampleFail() {
    return {
        type: REQUEST_ADD_NEW_SAMPLE_FAIL
    }
}