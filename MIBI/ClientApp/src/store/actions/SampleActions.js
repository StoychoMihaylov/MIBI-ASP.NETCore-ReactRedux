﻿import {
    REQUEST_ADD_NEW_SAMPLE,
    REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    REQUEST_ADD_NEW_SAMPLE_FAIL,
    REQUEST_GET_ALL_NAMES_OF_SAMPLES,
    REQUEST_GET_ALL_NAMES_OF_SAMPLES_SUCCESS,
    REQUEST_GET_ALL_NAMES_OF_SAMPLES_FAIL,
    REQUEST_GET_ALL_EXISTING_TAGS,
    REQUEST_GET_ALL_EXISTING_TAGS_SUCCESS,
    REQUEST_GET_ALL_EXISTING_TAGS_FAIL,
    REQUEST_GET_ALL_EXISTING_GROUPS,
    REQUEST_GET_ALL_EXISTING_GROUPS_SUCCESS,
    REQUEST_GET_ALL_EXISTING_GROUPS_FAIL,
    REQUEST_GET_ALL_EXISTING_NUTRIENTAGARPLATES,
    REQUEST_GET_ALL_EXISTING_NUTRIENTAGARPLATES_SUCCESS,
    REQUEST_GET_ALL_EXISTING_NUTRIENTAGARPLATES_FAIL,
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

function fetchSampleById() {
    return {
        type: REQUEST_GET_DETAILED_SAMPLE
    }
}

function fetchSampleByIdSuccess(data) {
    return {
        type: REQUEST_GET_DETAILED_SAMPLE_SUCCESS,
        payload: data
    }
}

function fetchSampleByIdFail(error) {
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



//*************************** Search Samples actions ***************************

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

//**********************************************************************

export function getAllExistingTagsFromServer() {
    return function (dispatch) {
        dispatch(getAllExistingTags()) // Dispatch get all ezisting names of samples
        axios.get(api + 'api/autocomplete/tags')
        .then(response => {
            dispatch(getAllExistingTagsSuccess(response["data"])) // Dispatch Successful request
        })
        .catch(err => {
            console.log(err)
            dispatch(getAllExistingTagsFail(err)) // Dispatch an error
        })
    }
}

export function getAllExistingTags() {
    return {
        type: REQUEST_GET_ALL_EXISTING_TAGS,
    }
}

export function getAllExistingTagsSuccess(data) {
    return {
        type: REQUEST_GET_ALL_EXISTING_TAGS_SUCCESS,
        payload: data
    }
}

export function getAllExistingTagsFail(error) {
    return {
        type: REQUEST_GET_ALL_EXISTING_TAGS_FAIL,
        payload: error
    }
}

//**********************************************************************

export function getAllExistingGroupsFromServer() {
    return function (dispatch) {
        dispatch(getAllExistingGroups()) // Dispatch get all ezisting names of samples
        axios.get(api + 'api/autocomplete/groups')
        .then(response => {
            dispatch(getAllExistingGroupsSuccess(response["data"])) // Dispatch Successful request
        })
        .catch(err => {
            console.log(err)
            dispatch(getAllExistingGroupsFail(err)) // Dispatch an error
        })
    }
}

export function getAllExistingGroups() {
    return {
        type: REQUEST_GET_ALL_EXISTING_GROUPS
    }
}

export function getAllExistingGroupsSuccess(data) {
    return {
        type: REQUEST_GET_ALL_EXISTING_GROUPS_SUCCESS,
        payload: data
    }
}

export function getAllExistingGroupsFail(error) {
    return {
        type: REQUEST_GET_ALL_EXISTING_GROUPS_FAIL,
        payload: error
    }
}

//**********************************************************************

export function fetchAllExistingNutrientAgarPlates() {
    return function (dispatch) {
        dispatch(getAllExistingNutrientAgarPlates()) // Dispatch get all ezisting names of samples
        axios.get(api + 'api/autocomplete/nutrientAgarPlates')
        .then(response => {
            dispatch(getAllExistingNutrientAgarPlatesSuccess(response["data"])) // Dispatch Successful request
        })
        .catch(err => {
            console.log(err)
            dispatch(getAllExistingNutrientAgarPlatesSuccess(err)) // Dispatch an error
        })
    }
}

export function getAllExistingNutrientAgarPlates() {
    return {
        type: REQUEST_GET_ALL_EXISTING_NUTRIENTAGARPLATES,
    }
}

export function getAllExistingNutrientAgarPlatesSuccess(data) {
    return {
        type: REQUEST_GET_ALL_EXISTING_NUTRIENTAGARPLATES_SUCCESS,
        payload: data
    }
}

export function getAllExistingNutrientAgarPlatesFail(error) {
    return {
        type: REQUEST_GET_ALL_EXISTING_NUTRIENTAGARPLATES_FAIL,
        payload: error
    }
}

//**********************************************************************

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