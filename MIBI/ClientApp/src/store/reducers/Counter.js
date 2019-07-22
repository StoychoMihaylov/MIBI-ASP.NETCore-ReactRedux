import { INCREMENT_COUNT } from '../../constants/actionTypes';
import { DECREMENT_COUNT } from '../../constants/actionTypes';

const initialState = { count: 0 };

export const reducer = (state, action) => {
  state = state || initialState;

    if (action.type === INCREMENT_COUNT) {
    return { ...state, count: state.count + 1 };
  }

    if (action.type === DECREMENT_COUNT) {
    return { ...state, count: state.count - 1 };
  }

  return state;
};
