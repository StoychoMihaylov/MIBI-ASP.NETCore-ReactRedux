import { applyMiddleware, combineReducers, compose, createStore } from 'redux'
import thunk from 'redux-thunk'
import { routerReducer, routerMiddleware } from 'react-router-redux'
import SampleReducer from './reducers/SampleReducer'
import NotificationReducer from './reducers/NotificationReducer'
import FilterReducer from './reducers/FilterReducer'
import AccountReducer from './reducers/AccountReducer'

export default function configureStore(history, initialState) {
  const reducers = {
      account: AccountReducer,
      filter: FilterReducer,
      notification: NotificationReducer,
      sample: SampleReducer
  }

  const middleware = [
      thunk,
      routerMiddleware(history)
  ]

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = []
  const isDevelopment = process.env.NODE_ENV === 'development';
  if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
      enhancers.push(window.devToolsExtension());
  }

  // Combine Reducers
  const rootReducer = combineReducers({
      ...reducers,
     routing: routerReducer
  })

  return createStore(
      rootReducer,
      initialState,
      compose(applyMiddleware(...middleware), ...enhancers)
  )
}
