import {
    REQUEST_ADD_NEW_SAMPLE,
    REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    REQUEST_ADD_NEW_SAMPLE_FAIL,
    FETCH_SAMPLE_BY_GIVEN_SEARCH_PARAMETERS,
    FETCH_SAMPLE_BY_GIVEN_SEARCH_PARAMETERS_SUCCESS,
    FETCH_SAMPLE_BY_GIVEN_SEARCH_PARAMETERS_FAIL,
    REQUEST_GET_DETAILED_SAMPLE,
    REQUEST_GET_DETAILED_SAMPLE_SUCCESS,
    REQUEST_GET_DETAILED_SAMPLE_FAIL
} from '../../constants/SampleActionTypes'
import { api } from '../../constants/api'
import axios from 'axios'

var qs = require('qs');

//*************************** Detailed Sample actions ***************************

export function fetchDetailedSampleById(id) {
    return function (dispatch) {
        dispatch(fetchSampleById())
        axios.get(api + 'api/sample/' + id)
        .then(response => {
            console.log(response)
            dispatch(fetchSampleByIdSuccess(response["data"]))
        })
        .catch(err => {
            console.log(err)
            dispatch(fetchSampleByIdFail(err))
        })
    }
}

export function fetchSampleById() {
    return {
        type: REQUEST_GET_DETAILED_SAMPLE
    }
}

export function fetchSampleByIdSuccess(data) {
    return {
        type: REQUEST_GET_DETAILED_SAMPLE_SUCCESS,
        payload: data
    }
}

export function fetchSampleByIdFail(error) {
    return {
        type: REQUEST_GET_DETAILED_SAMPLE_FAIL,
        payload: error
    }
}

//*************************** Create New Sample actions ***************************

export function addNewSampleInTheServer(imgFormdata) {
    return dispatch => {
        dispatch(createSample()) // Dispatch createNewSample
        return axios.post(api + 'api/sample', imgFormdata)
        .then(result => {
            dispatch(createSampleSuccess()) // Dispatch Successful created sample
            return result
        })
        .catch(err => {
            dispatch(createSampleFail(err)) // Dispatch for error
            return err
        })
    }
}

export function createSample() {
    return {
        type: REQUEST_ADD_NEW_SAMPLE
    }
}

export function createSampleSuccess(successMessage) {
    return {
        type: REQUEST_ADD_NEW_SAMPLE_SUCCESS,
        infoMessage: successMessage
    }
}

export function createSampleFail(error) {
    return {
        type: REQUEST_ADD_NEW_SAMPLE_FAIL,
        payload: error
    }
}


//********************************************************************************


export function fetchSamplesByGivenSearchParameters(bateriaParams) {
    return function (dispatch) {
        dispatch(fetchSamples())
        axios.get(api + 'api/samples', {
            params: bateriaParams,
            paramsSerializer: function(params) {
                return qs.stringify(params, {arrayFormat: 'repeat'})
            }
        })
        .then(response => {
            console.log(response)
            dispatch(fetchSamplesSuccess(response.data))
        })
        .catch(error => {
            console.log(error)
            dispatch(fetchSamplesFail(error))
        })
    }
}

export function fetchSamples() {
    return {
        type: FETCH_SAMPLE_BY_GIVEN_SEARCH_PARAMETERS,
    }
}

export function fetchSamplesSuccess(data) {
    return {
        type: FETCH_SAMPLE_BY_GIVEN_SEARCH_PARAMETERS_SUCCESS,
        payload: data
    }
}

export function fetchSamplesFail(error) {
    return {
        type: FETCH_SAMPLE_BY_GIVEN_SEARCH_PARAMETERS_FAIL,
        payload: error
    }
}