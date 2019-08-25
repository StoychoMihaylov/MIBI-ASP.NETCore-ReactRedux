import {
    REQUEST_ADD_NEW_SAMPLE,
    REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    REQUEST_ADD_NEW_SAMPLE_FAIL
} from '../constants/actionTypes'
import { api } from '../constants/api'
import axios from 'axios'

export function addNewSampleInTheServer(imgFormdata) {
    return function (dispatch) {
        dispatch(createSample()) // Dispatch createNewSample
        axios.post(api + 'api/sample', imgFormdata, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        })
        .then(result => {
            console.log(result)
            dispatch(createSampleSuccess()) // Dispatch Successful created sample
        })
        .catch(err => {
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