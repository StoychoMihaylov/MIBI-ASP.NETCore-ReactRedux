import {
    REQUEST_ADD_NEW_SAMPLE,
    REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    REQUEST_ADD_NEW_SAMPLE_FAIL
} from '../../constants/actionTypes'

const initialState = {
    newSample: {},
    isLoading: false,
    error: false
}

export default function sampleReducer(state = initialState, action) {
    switch (action.type) {
        case REQUEST_ADD_NEW_SAMPLE:
            return {
                ...state,
                newSample: state.newSample.concat(action.payload),
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
                error: true
            }
        default:
            return state
    }
}