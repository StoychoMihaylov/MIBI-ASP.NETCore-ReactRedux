import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Route } from 'react-router'
import { createSample } from '../actions/SampleActions'

class CreateNewSample extends Component {
    constructor() {
        super()

        this.state = {       
            name: "",  
            description: "",
            tags: "",
            images: [],
            
            previewImages: [],
        }

        this.handleDescriptionChange = this.handleDescriptionChange.bind(this)
        this.handleNameChange = this.handleNameChange.bind(this)
        this.handleImages = this.handleImages.bind(this)
        this.handleDescriptionChange = this.handleDescriptionChange.bind(this)
        this.handleTagsChange = this.handleTagsChange.bind(this)
        this.handleSubmit = this.handleSubmit.bind(this)
    }

    handleImages(images) {
        let imgs = Array.from(images.target.files)
        let urlObj = []

        for (var i = 0; i < imgs.length; i++) {
            if (imgs[i].type === "image/jpeg") {
                urlObj.push(URL.createObjectURL(imgs[i]))
            }
        }

        this.setState({
            previewImages: urlObj,
            images: imgs
        })
    }

    handleNameChange(event) {
        this.setState({ name: event.target.value })
    }

    handleDescriptionChange(event) {
        this.setState({ description: event.target.value })
    }

    handleTagsChange(event) {
        this.setState({ tags: event.target.value })
    }

    handleSubmit(event) {
        event.preventDefault();
        console.log(this.state)
 
        let newSample = {
            name: this.state.name,
            description: this.state.description,
            tags: this.state.tags,
            images: this.state.images
        }

        const payload = newSample
        this.props.createNewSample(payload)    
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
                            onChange={this.handleNameChange}
                        />
                    </label>
                    <br />
                    <label>
                        Description:
                        <textarea
                            placeholder="Text..."
                            onChange={this.handleDescriptionChange}
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
                        this.state.previewImages.map(
                            img => {
                                return (
                                    <div key={img}>
                                        <img src={img} alt="cat img" />
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
                            onChange={this.handleTagsChange}
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

function mapDispatchToProps(dispatch) {
    return {
        createNewSample: newSample => dispatch(createSample(newSample))
    }
}

function mapStateToProps(state) {
    return {
        isLoading: state.isLoading,
        error: state.error
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(CreateNewSample)