import {
    REQUEST_ADD_NEW_SAMPLE,
    REQUEST_ADD_NEW_SAMPLE_SUCCESS,
    REQUEST_ADD_NEW_SAMPLE_FAIL
} from '../../constants/actionTypes'

const initialState = {
    newSample: {
        name: "",
        description: "",
        tags: "",
        images: [],
    },
    isLoading: false,
    error: false
}

const SampleReducer = (state, action) => {
    state = state || initialState

    console.log(state, action)

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
                error: true
            }
        default:
            return state
    }
}

export default SampleReducer