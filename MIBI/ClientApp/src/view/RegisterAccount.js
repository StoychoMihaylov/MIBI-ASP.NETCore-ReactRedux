import React, { Component } from "react"
import { connect } from "react-redux"
import { Route } from "react-router"
import {
    infoNotification,
    successfulNotification,
    errorNotification
} from '../store/actions/NotificationActions'
import { registerAccount } from "../store/actions/AccountActions"
import '../styles/RegistrationAccount.css'

class RegisterAccount extends Component {
    constructor(props) {
        super(props)

        this.state = {
            name: "",
            email: "",
            password: "",
            confirmPassword: "",

            // fields validation
            nameValidation: "",
            emailValidation: "",
            passwordValidation: "",
            confirmPasswordValidation: "",
        }
    }

    emailValidation(email) {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }

    formValidation() {
        let isFormValid = true;

        if (this.state.name.length < 3) {
            this.setState({ nameValidation: "Name must be more than 3 charaters long!"})
            isFormValid = false
        } else {
            this.setState({ nameValidation: ""})
        }

        let isMailValid = this.emailValidation(this.state.email)
        if (! isMailValid) {
            this.setState({ emailValidation: "Email is not in a valid format!" })
            isFormValid = false
        } else {
            this.setState({ emailValidation: "" })
        }

        if (this.state.password.length < 3) {
            this.setState({ passwordValidation: "Password must be more than 3 charaters long!"})
            isFormValid = false
        } else {
            this.setState({ passwordValidation: ""})
        }

        if (this.state.password != this.state.confirmPassword) {
            this.setState({ confirmPasswordValidation: "Confirm password must be the same as your password!"})
            isFormValid = false
        } else {
            this.setState({ confirmPasswordValidation: ""})
        }

        return isFormValid
    }

    handleSubmit() {
        let isFormValid = this.formValidation()
        if (! isFormValid) {
            return;
        }

        let userData = {
            name: this.state.name,
            email: this.state.email,
            password: this.state.password,
            confirmPassword: this.state.confirmPassword,
        }

        this.props.registerAccount(userData)
            .then(response => {
                console.log(response)
                if (response.status === 200) {
                    let credentials = response.data
                    localStorage.setItem('token', credentials.token)
                    localStorage.setItem('userId', credentials.userId)
                    localStorage.setItem('userName', credentials.name)

                    this.props.successfulNotification("You are succesfully registered!")
                    this.props.history.push("/")
                } else if (response.response.status === 400) {
                    this.props.errorNotification(response.response.data)
                } else {
                    this.props.errorNotification("Something went wrong. Pleas try again")
                }
            })
        }

    render() {
        return (
            <div className="registerFormContainer">
                <div>
                    <img className="pageLogo" src={require("../content/logo/page-logo.png")} alt="logo"/>
                </div>
                <div>
                <div className="errorMessage">{this.state.nameValidation}</div>
                    <input
                        type="text"
                        placeholder="Name..."
                        name="name"
                        className="registrationField"
                        onChange={event => this.setState({ name: event.target.value })}
                    />
                </div>
                <div>
                    <div className="errorMessage">{this.state.emailValidation}</div>
                    <input
                        type="text"
                        placeholder="Email..."
                        name="email"
                        className="registrationField"
                        onChange={event => this.setState({ email: event.target.value })}
                    />
                </div>
                <div>
                    <div className="errorMessage">{this.state.passwordValidation}</div>
                    <input
                        type="password"
                        placeholder="Password..."
                        name="password"
                        className="registrationField"
                        onChange={event => this.setState({ password: event.target.value })}
                    />
                </div>
                <div>
                    <div className="errorMessage">{this.state.confirmPasswordValidation}</div>
                    <input
                        type="password"
                        placeholder="Confirm Password..."
                        name="confirmPassword"
                        className="registrationField"
                        onChange={event => this.setState({ confirmPassword: event.target.value })}
                    />
                </div>
                <div>
                <button
                    type="button"
                    className="saveBtn"
                    onClick={this.handleSubmit.bind(this)}>Register</button>
                <Route
                    render={({ history }) => (
                    <button
                        type="button"
                        className="backBtn"
                        onClick={() => { this.props.history.goBack() }}>Go Back&nbsp;</button>
                    )}
                />
                </div>
            </div>
        )
    }
}

const mapDispatchToProps = dispatch => {
    return {
        registerAccount: (userData) => dispatch(registerAccount(userData)),

         // Notifications
        infoNotification: (message) => dispatch(infoNotification(message)),
        successfulNotification: (message) => dispatch(successfulNotification(message)),
        errorNotification: (message) => dispatch(errorNotification(message))
    }
}

export default connect(null, mapDispatchToProps)(RegisterAccount)