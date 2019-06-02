// Action types
export const INCREMENT_COUNT = 'INCREMENT_COUNT';
export const DECREMENT_COUNT = 'DECREMENT_COUNT';

// Actions
export const actionCreators = {
    increment: () => ({ type: INCREMENT_COUNT }),
    decrement: () => ({ type: DECREMENT_COUNT })
};