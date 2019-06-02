import { INCREMENT_COUNT } from '../actions/CounterActions';
import { DECREMENT_COUNT } from '../actions/CounterActions';

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
