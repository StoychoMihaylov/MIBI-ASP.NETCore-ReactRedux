// Action types
export const REQUEST_WEATHER_FORECASTS = 'REQUEST_WEATHER_FORECASTS';
export const RECEIVE_WEATHER_FORECASTS = 'RECEIVE_WEATHER_FORECASTS';

// Actions
export const actionCreators = {
    requestWeatherForecasts: startDateIndex => async (dispatch, getState) => {
        if (startDateIndex === getState().weatherForecasts.startDateIndex) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }

        dispatch({ type: REQUEST_WEATHER_FORECASTS, startDateIndex });

        const url = `api/SampleData/WeatherForecasts?startDateIndex=${startDateIndex}`;
        const response = await fetch(url);
        const forecasts = await response.json();

        dispatch({ type: RECEIVE_WEATHER_FORECASTS, startDateIndex, forecasts });
    }
};