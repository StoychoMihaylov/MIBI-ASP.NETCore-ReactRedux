import React, { Component } from 'react'
import { connect } from 'react-redux'
import { Route } from 'react-router'
import { fetchDetailedSampleById } from '../store/actions/SampleActions'
import LoadingSpinner from '../components/LoadingSpinner'
import '../styles/DetailedSample.css'

class SampleDetails extends Component {
    constructor(props) {
        super(props)

        this.state = {
            isTagConsistencyEmpty: true
        }
    }

    componentWillMount() {
        let sampleId = this.props.match.params.id // Takes the id from url
        this.props.fetchDetailedSampleById(sampleId)
    }

    clickmeTest () {
    }

    render() {
        console.log("dsdsdsdsdsds")
        console.log(this.props.detailedSample)
        console.log("dsdsdsdsdsds")
        return(
            <div>
                {
                    this.props.isLoading === false
                    ?
                    <div className="detailedSampleContainer">
                        <h2>Name: {this.props.detailedSample.name}</h2>
                        <hr></hr>
                        <div className="detaildSampleImgsContainer">
                            {
                                this.props.detailedSample.tags != undefined
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
                        <br/>
                        <hr></hr>
                        <div>
                            <h3>Description:</h3>
                            <p>{this.props.detailedSample.description}</p>
                        </div>
                        <br/>
                        <hr></hr>
                        <h3>Group:
                            {
                                this.props.detailedSample.groups != undefined
                                ?
                                <span className="sampleGroup">{this.props.detailedSample.groups[0].name}</span>
                                :
                                null
                            }
                        </h3>
                        <br/>
                        <hr></hr>
                        <div>
                            <h3>Nutrient Agar Plates:</h3>
                            <div className="sampleNutrientAgarPlatesContainer">
                                {
                                    this.props.detailedSample.nutrientAgarPlates != undefined
                                    ?
                                    this.props.detailedSample.nutrientAgarPlates.map((nutrientAgarPlate, index) => {
                                        return (
                                        <button key={index} className="nutrients">
                                            {nutrientAgarPlate.name}
                                        </button>
                                        )
                                    })
                                    :
                                    null
                                }
                            </div>
                        </div>
                        <br/>
                        <hr></hr>
                        <div>
                            <h3>Tags:</h3>
                            <div className="tagContainer">
                                <div>
                                    <h4>Elevations</h4>
                                    {
                                        this.props.detailedSample.tags != undefined
                                        ?
                                        this.props.detailedSample.tags.map((tag, index) => {
                                            if (tag.category === "Elevations") {
                                                return (
                                                <button key={index} className="tags">
                                                    {tag.name}
                                                    <img src={require('../content/tagIcons/' + tag.iconUrl)} className="tagIcon"/>
                                                </button>
                                                )
                                            }
                                        })
                                        :
                                        null
                                    }
                                </div>
                                <br/>
                                <div>
                                    <h4>Form</h4>
                                    {
                                        this.props.detailedSample.tags != undefined
                                        ?
                                        this.props.detailedSample.tags.map((tag, index) => {
                                            if (tag.category === "Form") {
                                                return (
                                                <button key={index} className="tags">
                                                    {tag.name}
                                                    <img src={require('../content/tagIcons/' + tag.iconUrl)} className="tagIcon"/>
                                                </button>
                                                )
                                            }
                                        })
                                        :
                                        null
                                    }
                                </div>
                                <br/>
                                <div>
                                    <h4>Surface appearance</h4>
                                    {
                                        this.props.detailedSample.tags != undefined
                                        ?
                                        this.props.detailedSample.tags.map((tag, index) => {
                                            if (tag.category === "Surface appearance") {
                                                return (
                                                <button key={index} className="tags">
                                                    {tag.name}
                                                </button>
                                                )
                                            }
                                        })
                                        :
                                        null
                                    }
                                </div>
                                <br/>
                                <div>
                                    <h4>Consistency</h4>
                                    {
                                        this.props.detailedSample.tags != undefined
                                        ?
                                        this.props.detailedSample.tags.map((tag, index) => {
                                            if (tag.category === "Consistency") {
                                                return (
                                                    <button key={index} className="tags">
                                                        {tag.name}
                                                    </button>
                                                )
                                            }
                                        })
                                        :
                                        null
                                    }
                                </div>
                                <br/>
                                <div>
                                    <h4>Colors</h4>
                                    {
                                        this.props.detailedSample.tags != undefined
                                        ?
                                        this.props.detailedSample.tags.map((tag, index) => {
                                            if (tag.category === "Colors") {
                                                return (
                                                    <button key={index} className="tags">
                                                        {tag.name}
                                                        <span className="tagColor" style={{backgroundColor: tag.color}}>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                    </button>
                                                )
                                            }
                                        })
                                        :
                                        null
                                    }
                                </div>
                            </div>
                        </div>
                        <br/>
                        <hr></hr>
                        <span>Created by: <strong>{this.props.detailedSample.createdBy}</strong></span>
                        <span> on {this.props.detailedSample.createdOn != undefined
                                ?
                                `${this.props.detailedSample.createdOn.split('T')[1].split('.')[0]}h - ${this.props.detailedSample.createdOn.split('T')[0].split('-')[2]}.${this.props.detailedSample.createdOn.split('T')[0].split('-')[1]}.${this.props.detailedSample.createdOn.split('T')[0].split('-')[0]}`
                                :
                                ""}
                        </span>
                        <br/>
                        <hr></hr>
                        <div className="backBtnDiv">
                            <Route
                                render={({ history }) => (
                                <button
                                    type="button"
                                    className="sampleBackBtn"
                                    onClick={() => { this.props.history.goBack() }}>BACK</button>
                                )}
                            />
                        </div>
                    </div>
                    :
                    <LoadingSpinner/>
                }
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