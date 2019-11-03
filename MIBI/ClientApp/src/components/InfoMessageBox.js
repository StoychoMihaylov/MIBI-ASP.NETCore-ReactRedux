import React from 'react';
import { connect } from 'react-redux'
import "../styles/InfoMessageBox.css"

class InfoMessageBox extends React.Component {
    render() {
        return (
           <div>
               <div className="infoMessageBoxConteiner">
                    {
                        this.props.infoMessage != undefined && this.props.infoMessage.length > 0
                        ?
                        <div className="globalInfoMessage">
                            <span>{this.props.infoMessage}</span>
                        </div>
                        :
                        null
                    }
                    {
                        this.props.successMessage != undefined && this.props.successMessage.length > 0
                        ?
                        <div className="globalSuccessMessage">
                            <span>{this.props.successMessage}</span>
                        </div>
                        :
                        null
                    }
                    {
                        this.props.errorMessage != undefined && this.props.errorMessage.length > 0
                        ?
                        <div className="globalErrorMessage">
                            <span>{this.props.errorMessage}</span>
                        </div>
                        :
                        null
                    }
                </div>
           </div>
        )
    }
}

const mapStateToProps = state => {
    console.log("here!")
    console.log(state)
    return {
        infoMessage: state.common.infoMessage,
        successMessage: state.common.successMessage,
        errorMessage: state.common.errorMessage,
        isLoading: state.sample.isLoading
    }
}

export default connect(mapStateToProps, () => {})(InfoMessageBox)