import React, { Component } from 'react'
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
          
            previewImages: [],
        }

        console.log(this.props.newSample)

        this.handleImages = this.handleImages.bind(this)
        this.handleSubmit = this.handleSubmit.bind(this)
    }

    handleImages(images) {
        // TO FIX Image uploading
        let imgs = Array.from(images.target.files)
        let previewImages = []

        for (var i = 0; i < imgs.length; i++) {
            if (imgs[i].type === "image/jpeg") {
                let newImg = {
                    name: imgs[i].name,
                    type: imgs[i].type,
                    url: URL.createObjectURL(imgs[i]),
                    base64Img: 
                }

                previewImages.push(newImg)
            }
        }

        this.setState({
            images: previewImages
        })
    }

    handleSubmit(event) {
        event.preventDefault();

        let tags = this.state.tags.toString().split(",").map(item => item.trim())
 
        let newSample = {
            name: this.state.name,
            description: this.state.description,
            tags: tags,
            images: this.state.images
        }

        this.props.createSample(newSample)
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
        createSample: (newSample) => dispatch(addNewSampleInTheServer(newSample))
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(CreateNewSample)