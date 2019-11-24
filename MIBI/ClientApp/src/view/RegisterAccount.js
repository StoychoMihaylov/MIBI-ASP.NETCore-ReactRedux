import React, { Component } from "react"
import { connect } from "react-redux"
import {
    infoNotification,
    successfulNotification,
    errorNotification
} from '../store/actions/NotificationActions'
import { registerAccount } from "../store/actions/AccountActions"

class RegisterAccount extends Component {
    constructor(props) {
        super(props)

        this.state = {
            name: "",
            email: "",
            password: "",
            confirmPassword: ""
        }
    }

    handleSubmit() {
        this.props.registerAccount(this.state);
    }

    render() {
        return (
            <div>
                <div>
                    <input
                        type="text"
                        placeholder="Name..."
                        name="name"
                        onChange={event => this.setState({ userName: event.target.value })}
                    />
                </div>
                <div>
                    <input
                        type="text"
                        placeholder="Email..."
                        name="email"
                        onChange={event => this.setState({ email: event.target.value })}
                    />
                </div>
                <div>
                    <input
                        type="password"
                        placeholder="Password..."
                        name="password"
                        onChange={event => this.setState({ password: event.target.value })}
                    />
                </div>
                <div>
                    <input
                        type="password"
                        placeholder="Confirm Password..."
                        name="confirmPassword"
                        onChange={event => this.setState({ confirmPassword: event.target.value })}
                    />
                </div>
                <div>
                <button
                    type="button"
                    onClick={this.handleSubmit.bind(this)}>Register</button>
                </div>
            </div>
        )
    }
}

const mapStateToProps = state => {
    return {
        
    }
}

const mapDispatchToProps = dispatch => {
    return {
        registerAccount: (sampleId) => dispatch(registerAccount(sampleId)),

         // Notifications
        infoNotification: (message) => dispatch(infoNotification(message)),
        successfulNotification: (message) => dispatch(successfulNotification(message)),
        errorNotification: (message) => dispatch(errorNotification(message))
    }
}

export default connect(null, mapDispatchToProps)(RegisterAccount)