import React, { Component } from "react"
import { connect } from "react-redux"
import { Route } from "react-router"
import { fetchDetailedSampleById } from "../store/actions/SampleActions"

class SampleDetails extends Component {
    constructor(props) {
        super(props)

        this.state = {
            group: ""
        }
    }

    componentWillMount() {
        let sampleId = this.props.match.params.id // Takes the id from url
        this.props.fetchDetailedSampleById(sampleId)
    }

    clickmeTest () {
    }

    render() {
        return(
            <div>
                <h1>Name: {this.props.detailedSample.name}</h1>
                <div>
                    {
                        this.props.detailedSample.sampleTags != undefined
                        ?
                        this.props.detailedSample.images.map((img, index) => {
                            return (
                            <div key={index}>
                                <img className="image" id={img.id} src={'https://localhost:44376/Images/' + img.url} alt="image" />
                            </div>
                            )
                        })
                        :
                        ""
                    }
                </div>
                <p>Description: {this.props.detailedSample.description}</p>
                <h2>Group: {this.props.detailedSample.sampleGroups != undefined ? this.props.detailedSample.sampleGroups[0].group.name : ""}</h2>
                <div>
                    <h2>Nutrient Agar Plates</h2>
                    {
                        this.props.detailedSample.sampleNutrientAgarPlates != undefined
                        ?
                        this.props.detailedSample.sampleNutrientAgarPlates.map((nutrient, index) => {
                            return (
                            <div key={index}>
                                {nutrient.name}
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
                        this.props.detailedSample.sampleTags.map((tag, index) => {
                            return (
                            <div key={index}>
                                {tag.name}
                            </div>
                            )
                        })
                        :
                        ""
                    }
                </div>
                <h2>Created on: {this.props.detailedSample.createdOn}</h2>
                <h2>Created by: {this.props.detailedSample.createdBy}</h2>
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