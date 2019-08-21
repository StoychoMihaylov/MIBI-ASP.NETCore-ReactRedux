import {
    REQUEST_ADD_NEW_SAMPLE,
    REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    REQUEST_ADD_NEW_SAMPLE_FAIL
} from '../constants/actionTypes'
import { api } from '../constants/api'
import axios from 'axios'

export function addNewSampleInTheServer(newSample, imgFormdata) {
    console.log(newSample, imgFormdata)
    return function (dispatch) {
        dispatch(createSample()) // Dispatch createNewSample

        //return fetch(api + 'api/sample', newSample, {
        //    method: 'POST',
        //    headers: {
        //        'Content-Type': 'multipart/form-data',
        //    }
        //    })
        //    .then(json => {
        //        console.log("SUCCESSFUL RESPONSE:")
        //        console.log(json)

        //        dispatch(createSampleSuccess()) // Dispatch Successful created sample
        //    })
        //    .catch(err => {
        //        console.log("ERROR:")
        //        console.log(err)

        //        dispatch(createSampleFail(true)) // Dispatch for error
        //    })

        axios.post(api + 'api/sample', imgFormdata, {
            headers: {
                'name': newSample.name,
                'description': newSample.description,
                'tags': newSample.tags,
                'Content-Type': 'multipart/form-data'
            }
        })
        .then(result => { console.log(result) })
        .catch(err => { console.log(err)})    
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