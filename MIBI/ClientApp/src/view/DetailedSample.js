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
                <br/>
                <h3>Group:
                    {
                        this.props.detailedSample.sampleGroups != undefined
                        ?
                        <span className="sampleGroup">{this.props.detailedSample.sampleGroups[0].group.name}</span>
                        :
                        ""
                    }
                </h3>
                <br/>
                <div>
                    <h2>Nutrient Agar Plates:</h2>
                    {
                        this.props.detailedSample.sampleNutrientAgarPlates != undefined
                        ?
                        this.props.detailedSample.sampleNutrientAgarPlates.map((nutrientObj, index) => {
                            return (
                            <span key={index} className="sampleNutrintAgarPlates">
                                {nutrientObj.nutrientAgarPlate.name}
                            </span>
                            )
                        })
                        :
                        ""
                    }
                </div>
                <br/>
                <div>
                    <h2>Tags</h2>
                    {
                        this.props.detailedSample.sampleTags != undefined
                        ?
                        this.props.detailedSample.sampleTags.map((tagObj, index) => {
                            return (
                            <span key={index} className="tags">
                                {tagObj.tag.name}
                            </span>
                            )
                        })
                        :
                        ""
                    }
                </div>
                <br/>
                <span>Created by: <strong>{this.props.detailedSample.createdBy}</strong></span>
                <span> on {this.props.detailedSample.createdOn != undefined
                    ?
                    `${this.props.detailedSample.createdOn.split('T')[1].split('.')[0]}h - ${this.props.detailedSample.createdOn.split('T')[0].split('-')[2]}.${this.props.detailedSample.createdOn.split('T')[0].split('-')[1]}.${this.props.detailedSample.createdOn.split('T')[0].split('-')[0]}`
                    :
                    ""}
                </span>
                <br/>
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