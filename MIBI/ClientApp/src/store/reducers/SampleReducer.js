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

const initialState = {
    samples: [],
    detailedSample: {},

    isLoading: false,
    error: false
}

const SampleReducer = (state, action) => {
    state = state || initialState

    switch (action.type) {
        case REQUEST_GET_DETAILED_SAMPLE:
            return {
                ...state,
                isLoading: true
            }
        case REQUEST_GET_DETAILED_SAMPLE_SUCCESS:
            return {
                ...state,
                detailedSample: action.payload,
                isLoading: false
            }
        case REQUEST_GET_DETAILED_SAMPLE_FAIL:
            return {
                ...state,
                isLoading: false,
                error: action.payload
            }
        case FETCH_SAMPLE_BY_GIVEN_SEARCH_PARAMETERS:
            return {
                ...state,
                isLoading: true
            }
        case FETCH_SAMPLE_BY_GIVEN_SEARCH_PARAMETERS_SUCCESS:
            return {
                ...state,
                samples: action.payload,
                isLoading: false
            }
        case FETCH_SAMPLE_BY_GIVEN_SEARCH_PARAMETERS_FAIL:
            return {
                ...state,
                isLoading: false,
                error: action.payload
            }
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
        default:
            return state
    }
}

export default SampleReducer