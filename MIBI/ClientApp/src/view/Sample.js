import React, { Component } from 'react'
import { connect } from 'react-redux'
import { Route } from 'react-router'
import {
    getAllNamesOfExistingSamples,
    getAllExistingtagsFromServer
} from '../store/actions/SampleActions'
import "../styles/Sample.css"

class SampleView extends Component {
    constructor(props) {
        super(props)

        this.state = {
            searchSampleName: "",
            optionSetNames: [],
            selectedTags: []
        }
    }

    async componentWillMount() {
        this.props.fetchAllNamesOfExistingSamples()
        this.props.fetchAllExistingtags()
    }

    setTheSelectedOption(event) {
        let value = event.target.value

        this.props.autocompleteNamesOfSamples.forEach(opt => {
            if(opt.name.toLowerCase() === value.toLowerCase()) {
                this.setState({
                    searchSampleName: value
                })

                document.getElementById("autocompleateListOfNames").style.display = "none"
            }
        })
    }

    showOptionSetOfNames(event) {
        let value = event.target.value
        let newOptSet = []

        // set value to the input
        this.setState({
            searchSampleName: value
        })

        // filter the option set values
        if(value.length > 0) {
            this.props.autocompleteNamesOfSamples.forEach(opt => {
                if(opt.name.toLowerCase().includes(value.toLowerCase())) {
                    newOptSet.push(opt)
                }
            })

            this.setState({
                optionSetNames: newOptSet
            })
            document.getElementById("autocompleateListOfNames").style.display = "block"
        } else {
            document.getElementById("autocompleateListOfNames").style.display = "none"
        }
    }

    addsearchingByTag(event) {
        let id = event.target.id
        let value = event.target.value
        let tabIndex = event.target.tabIndex
        let tags = this.state.selectedTags

        if(tabIndex === 0) {
            let element = document.getElementById(id)
            element.style.backgroundColor = "#66B2FF"
            element.tabIndex = "1"

            this.props.allExistingTags.forEach(tag => {
                if(tag.name.toLowerCase() === value.toLowerCase()) {
                    tags.push(tag)
                }
            })

            this.setState({
                selectedTags: tags
            })

        } else if (tabIndex === 1) {
            let element = document.getElementById(id)
            element.style.backgroundColor = "grey"
            element.tabIndex = "0"

            this.props.allExistingTags.forEach(tag => {
                if(tag.name.toLowerCase() === value.toLowerCase()) {
                    tags.splice(tags.indexOf(value), 1)
                }
            })

            this.setState({
                selectedTags: tags
            })
        }
    }

    render() {
        let optionSetOfNames = this.state.optionSetNames.map((rec, index) => (
            <div key={index}>
                <input
                    id="optionName"
                    readOnly
                    type="text"
                    value={rec.name}
                    onClick={this.setTheSelectedOption.bind(this)}/>
            </div>
        ))

        return(
        <div className="conteiner">
            <div className="searchingBar">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <input
                                    id="searchInput"
                                    placeholder="Search..."
                                    value={this.state.searchSampleName}
                                    onChange={this.showOptionSetOfNames.bind(this)}
                                />
                                <div id="autocompleateListOfNames">
                                    {optionSetOfNames}
                                </div>
                            </td>
                            <td>
                                <button id="searchBtn"><img alt=""/></button>
                            </td>
                            <td>
                                <Route render={({ history }) => (
                                <button
                                    id="addSampleBtn"
                                        type='button'
                                    onClick={() => { history.push('/addSample') }}>Add Sample</button>
                                )} />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div className="tagsConteiner">
                    <span id="tagsTitle">Tags</span>
                    <br/>
                    {
                     this.props.allExistingTags.map((tag, index) => (
                        <button
                            readOnly
                            key={index}
                            id={tag.id}
                            className="tags"
                            tabIndex="0"
                            type="text"
                            value={tag.name}
                            onClick={this.addsearchingByTag.bind(this)}>{tag.name}</button>
                        ))
                    }
                </div>
            </div>
        </div>
        )
    }
}

const mapStateToProps = state => {
    console.log(state)
    return {
      allExistingTags: state.sample.allExistingTags,
      autocompleteNamesOfSamples: state.sample.autocompleteNamesOfSamples,
      isLoading: state.sample.isLoading,
      error: state.sample.error
    };
  };

const mapDispatchToProps = dispatch => {
    return {
        fetchAllNamesOfExistingSamples: () => dispatch(getAllNamesOfExistingSamples()),
        fetchAllExistingtags: () => dispatch(getAllExistingtagsFromServer())
    };
  };

export default connect(mapStateToProps, mapDispatchToProps)(SampleView)
