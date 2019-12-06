import React from 'react'
import Loader from 'react-loader-spinner'
import '../styles/LoadingSpinner.css'

export default class LoadingSpinner extends React.Component {
    render() {
        return (
            <div className="LoadingSpinner">
                <Loader
                    type="ThreeDots"
                    color="#00BFFF"
                    height="100"
                    width="100"
                />
            </div>
        );
    }
}