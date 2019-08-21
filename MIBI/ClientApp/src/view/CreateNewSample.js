﻿import React, { Component } from 'react'
import { connect } from 'react-redux'
import { Route } from 'react-router'
import { addNewSampleInTheServer } from '../actions/SampleActions'

class CreateNewSample extends Component {
    constructor(props) {
        super(props)

        this.state = {       
            name: "",  
            description: "",
            tags: [],
            images: [],
            files: {}
        }

        console.log(this.props.newSample)

        this.handleImages = this.handleImages.bind(this)
        this.handleSubmit = this.handleSubmit.bind(this)
    }

    handleImages(images) {
        let imgs = Array.from(images.target.files)
        let previewImages = []

        for (var i = 0; i < imgs.length; i++) {
            if (imgs[i].type === "image/jpeg") {
                let newImg = {
                    url: URL.createObjectURL(imgs[i]),
                }

                previewImages.push(newImg)
            }
        }

        this.setState({
            images: previewImages,
            files: imgs
        })
    }

    handleSubmit(event) {
        event.preventDefault();

        let formDataImages = new FormData();
        if (this.state.files.length > 0) { 
            this.state.files.forEach(file => {
                formDataImages.append("image", file)
            })
        }
        
        let tags = this.state.tags.toString()
 
        let newSample = {
            name: this.state.name,
            description: this.state.description,
            tags: tags,
        }

        this.props.createSample(newSample, formDataImages)
    }

    render() {
        return (
            <div>
                <h1>Create new Sample View</h1>
                <form onSubmit={this.handleSubmit}>
                    <label>
                        Name:
                        <input
                            type="text"
                            placeholder="Type a name"
                            name="name"
                            onChange={(event) => this.setState({ name: event.target.value })}
                        />
                    </label>
                    <br />
                    <label>
                        Description:
                        <textarea
                            placeholder="Text..."
                            onChange={(event) => this.setState({ description: event.target.value })}
                        />
                    </label>
                    <br />
                    {/* Image Uploader */}
                    <label>
                        Upload Images:
                        <input
                            type="file"
                            multiple={true}
                            onChange={this.handleImages}
                        />
                    </label>
                    <br />
                    {/* Image previewer */}
                    {
                        this.state.images.map(
                            img => {
                                return (
                                    <div key={img.name}>
                                        <img src={img.url} alt="cat img" />
                                    </div>
                                    )
                            }
                        )
                    }
                    <br />
                    <label>
                        Tags:
                        <input
                            type="text"
                            placeholder="tag1, tag2, tag3..."
                            name="tags"
                            onChange={(event) => { this.setState({ tags: event.target.value }) }}
                        />
                    </label>
                    <br />
                    <button type="submit">SAVE</button>
                    <Route render={({ history }) => (
                        <button type="button" onClick={() => { this.props.history.goBack() }}>
                            Back
                        </button>
                    )} />
                </form>
            </div>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        newSample: state.sample.newSample,
        isLoading: state.sample.isLoading,
        error: state.sample.error
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        createSample: (newSample, imageFormData) => dispatch(addNewSampleInTheServer(newSample, imageFormData))
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(CreateNewSample)