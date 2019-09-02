import {
    REQUEST_ADD_NEW_SAMPLE,
    REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    REQUEST_ADD_NEW_SAMPLE_FAIL,
    REQUEST_GET_ALL_NAMES_OF_SAMPLES,
    REQUEST_GET_ALL_NAMES_OF_SAMPLES_SUCCESS,
    REQUEST_GET_ALL_NAMES_OF_SAMPLES_FAIL
} from '../../constants/actionTypes'

import { api } from '../../constants/api'
import axios from 'axios'

//********** Create New Sample **********

export function addNewSampleInTheServer(imgFormdata) {
    return function (dispatch) {
        dispatch(createSample()) // Dispatch createNewSample
        axios.post(api + 'api/sample', imgFormdata, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        })
        .then(result => {
            dispatch(createSampleSuccess()) // Dispatch Successful created sample
        })
        .catch(err => {
            console.log(err)
            dispatch(createSampleFail(err)) // Dispatch for error
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

//********** Sample actions **********

export function getAllNamesOfExistingSamples() {
    return function (dispatch) {
        dispatch(getAllExistingNamesOfSamples()) // Dispatch get all ezisting names of samples
        axios.get(api + 'api/autocomplete/names')
        .then(response => {
            dispatch(getAllExistingNamesOfSamplesSuccess(response["data"])) // Dispatch Successful request
        })
        .catch(err => {
            console.log(err)
            dispatch(getAllExistingNamesOfSamplesFail(err)) // Dispatch an error
        })
    }
}

export function getAllExistingNamesOfSamples() {
    return {
        type: REQUEST_GET_ALL_NAMES_OF_SAMPLES
    }
}

export function getAllExistingNamesOfSamplesSuccess(data) {
    return {
        type: REQUEST_GET_ALL_NAMES_OF_SAMPLES_SUCCESS,
        payload: data
    }
}

export function getAllExistingNamesOfSamplesFail(error) {
    return {
        type: REQUEST_GET_ALL_NAMES_OF_SAMPLES_FAIL,
        payload: error
    }
}