import React, { Component } from "react"
import { connect } from "react-redux"
import "../styles/Notification.css"

class Notification extends Component {
    render () {
        return(
            <div>
                {
                    this.props.infoMessage.length > 0
                    ?
                    <div className="infoNotificationMessage">{this.props.infoMessage}</div>
                    :
                    null
                }

                {
                    this.props.successfulMessage.length > 0
                    ?
                    <div className="successNotificationfulMessage">{this.props.successfulMessage}</div>
                    :
                    null
                }

                {
                    this.props.errorMessage.length > 0
                    ?
                    <div className="errorNotificationMessage">{this.props.errorMessage}</div>
                    :
                    null
                }

            </div>
        )
    }
}

const mapStateToProps = state => {
    return {
        infoMessage: state.notification.infoMessage,
        successfulMessage: state.notification.successfulMessage,
        errorMessage: state.notification.errorMessage
    }
  }

export default connect(mapStateToProps, null)(Notification)