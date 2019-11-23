import {
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
} from '../../constants/FilterActionTypes'
import { api } from '../../constants/api'
import axios from 'axios'

//*************************** Filter Samples actions ***************************

export function getAllNamesOfExistingSamples() {
    return function (dispatch) {
        dispatch(getAllExistingNamesOfSamples()) // Dispatch get all ezisting names of samples
        axios.get(api + 'api/filter/names')
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
        axios.get(api + 'api/filter/tags')
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
        axios.get(api + 'api/filter/groups')
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
        axios.get(api + 'api/filter/nutrientAgarPlates')
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