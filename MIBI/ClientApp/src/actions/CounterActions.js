import { INCREMENT_COUNT, DECREMENT_COUNT } from '../constants/actionTypes'

// Actions
export const actionCreators = {
    increment: () => ({ type: INCREMENT_COUNT }),
    decrement: () => ({ type: DECREMENT_COUNT })
};