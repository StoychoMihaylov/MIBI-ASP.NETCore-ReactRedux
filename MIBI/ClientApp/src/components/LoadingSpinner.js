import React from 'react'
import Loader from 'react-loader-spinner'

export default class LoadingSpinner extends React.Component {
    render() {
        return (
            <Loader
                type="ThreeDots"
                color="#00BFFF"
                height="100"
                width="100"
            />
        );
    }
}