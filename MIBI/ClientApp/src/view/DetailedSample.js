import React, { Component } from "react"
import { connect } from "react-redux"
import { Route } from "react-router"
import { fetchDetailedSampleById } from "../store/actions/SampleActions"
import "../styles/DetailedSample.css"

class SampleDetails extends Component {
    constructor(props) {
        super(props)

        this.state = {
        }
    }

    componentWillMount() {
        let sampleId = this.props.match.params.id // Takes the id from url
        this.props.fetchDetailedSampleById(sampleId)
    }

    clickmeTest () {
    }

    render() {
        console.log(this.props.detailedSample.sampleNutrientAgarPlates)
        return(
            <div>
                <h1>Name: {this.props.detailedSample.name}</h1>
                <div>
                    {
                        this.props.detailedSample.sampleTags != undefined
                        ?
                        this.props.detailedSample.images.map((img, index) => {
                            return (
                            <div key={index} className="imgDiv">
                                <img id={img.id} src={'https://localhost:44376/Images/' + img.url} className="imageDetail" alt="image" />
                            </div>
                            )
                        })
                        :
                        ""
                    }
                </div>
                <div>
                    <h3>Description:</h3>
                    <p>{this.props.detailedSample.description}</p>
                </div>
                <h3>Group: {this.props.detailedSample.sampleGroups != undefined ? this.props.detailedSample.sampleGroups[0].group.name : ""}</h3>
                <div>
                    <h2>Nutrient Agar Plates</h2>
                    {
                        this.props.detailedSample.sampleNutrientAgarPlates != undefined
                        ?
                        this.props.detailedSample.sampleNutrientAgarPlates.map((nutrientObj, index) => {
                            return (
                            <div key={index}>
                                {nutrientObj.nutrientAgarPlate.name}
                            </div>
                            )
                        })
                        :
                        ""
                    }
                </div>
                <div>
                    <h2>Tags</h2>
                    {
                        this.props.detailedSample.sampleTags != undefined
                        ?
                        this.props.detailedSample.sampleTags.map((tagObj, index) => {
                            return (
                            <div key={index}>
                                {tagObj.tag.name}
                            </div>
                            )
                        })
                        :
                        ""
                    }
                </div>
                <h2>Created on: {this.props.detailedSample.createdOn}</h2>
                <h2>Created by: {this.props.detailedSample.createdBy}</h2>
                <Route
                    render={({ history }) => (
                    <button
                        type="button"
                        onClick={() => { this.props.history.goBack() }}>BACK</button>
                    )}
                />
            </div>
        )
    }
}

const mapStateToProps = state => {
    return {
        detailedSample: state.sample.detailedSample,
        isLoading: state.sample.isLoading,
        error: state.sample.error
    }
}

const mapDispatchToProps = dispatch => {
    return {
        fetchDetailedSampleById: (sampleId) => dispatch(fetchDetailedSampleById(sampleId))
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(SampleDetails)