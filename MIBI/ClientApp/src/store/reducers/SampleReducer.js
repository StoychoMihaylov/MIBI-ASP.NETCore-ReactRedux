import {
    REQUEST_ADD_NEW_SAMPLE,
    REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    REQUEST_ADD_NEW_SAMPLE_FAIL,
    REQUEST_GET_ALL_NAMES_OF_SAMPLES,
    REQUEST_GET_ALL_NAMES_OF_SAMPLES_SUCCESS,
    REQUEST_GET_ALL_NAMES_OF_SAMPLES_FAIL
} from '../../constants/actionTypes'

const initialState = {
    autocompleteNamesOfSamples: [],
    isLoading: false,
    error: false
}

const SampleReducer = (state, action) => {
    state = state || initialState
    
    switch (action.type) {
        case REQUEST_ADD_NEW_SAMPLE:
            return {
                ...state,
                isLoading: true
            }
        case REQUEST_ADD_NEW_SAMPLE_SUCCESS:
            return {
                ...state,
                isLoading: false,
            }
        case REQUEST_ADD_NEW_SAMPLE_FAIL:
            return {
                ...state,
                isLoading: false,
                error: action.payload
            }
        case REQUEST_GET_ALL_NAMES_OF_SAMPLES:
            return {
                ...state,
                isLoading: true
            }
        case REQUEST_GET_ALL_NAMES_OF_SAMPLES_SUCCESS:
            return {
                ...state,
                autocompleteNamesOfSamples: action.payload,
                isLoading: false
            }
        case     REQUEST_GET_ALL_NAMES_OF_SAMPLES_FAIL:
            return {
                ...state,
                isLoading: false,
                error: action.payload
            }
        default:
            return state
    }
}

export default SampleReducer