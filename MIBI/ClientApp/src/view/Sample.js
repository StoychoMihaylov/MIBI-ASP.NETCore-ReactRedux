import React, { Component } from 'react'
import { connect } from 'react-redux'
import { Route } from 'react-router'
import {
    getAllNamesOfExistingSamples,
    getAllExistingTagsFromServer,
    getAllExistingGroupsFromServer,
    fetchSamplesByGivenSearchParameters
} from '../store/actions/SampleActions'
import "../styles/Sample.css"

class SampleView extends Component {
    constructor(props) {
        super(props)

        this.state = {
            searchSampleName: "",
            optionSetNames: [],
            selectedTags: [],
            selectedGroups: [],
            isTagsBtnClicked: false,
            isGroupsBtnClicked: false
        }
    }

    async componentWillMount() {
        this.props.fetchAllNamesOfExistingSamples()
        this.props.fetchAllExistingTags()
        this.props.fetchAllExistingGroups()
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

    handleSearchBtnClickEvent() {
        let tagNames = []
        let groupNames = []

        this.state.selectedTags.forEach((tag) => {
            tagNames.push(tag.name)
        })

        this.state.selectedGroups.forEach((group) => {
            groupNames.push(group.name)
        })

        let searchParameters = {
                bacteriaName: this.state.searchSampleName,
                tags: tagNames,
                groups: groupNames
        }

        this.props.fetchSamplesByGivenParameters(searchParameters)
    }

    addSearchingByTag(event) {
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

    addSearchingByGroup(event) {
        let id = event.target.id
        let value = event.target.value
        let tabIndex = event.target.tabIndex
        let groups = this.state.selectedGroups

        if(tabIndex === 0) {
            let element = document.getElementById(id)
            element.style.backgroundColor = "#66B2FF"
            element.tabIndex = "1"

            this.props.allExistingGroups.forEach(group => {
                if(group.name.toLowerCase() === value.toLowerCase()) {
                    groups.push(group)
                }
            })

            this.setState({
                selectedGroups: groups
            })

        } else if (tabIndex === 1) {
            let element = document.getElementById(id)
            element.style.backgroundColor = "grey"
            element.tabIndex = "0"

            this.props.allExistingGroups.forEach(group => {
                if(group.name.toLowerCase() === value.toLowerCase()) {
                    groups.splice(groups.indexOf(value), 1)
                }
            })

            this.setState({
                selectedGroups: groups
            })
        }
    }

    handleGroupsBtnClick() {
        let state = this.state.isGroupsBtnClicked

        if(state) {
            this.setState({
                isGroupsBtnClicked: false,
                selectedGroups: []
            })
        } else if(! state) {
            this.setState({
                isGroupsBtnClicked: true
            })
        }
    }

    handleTagsBtnClick(){
        let state = this.state.isTagsBtnClicked

        if(state) {
            this.setState({
                isTagsBtnClicked: false,
                selectedTags: []
            })
        } else if(! state) {
            this.setState({
                isTagsBtnClicked: true
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

        let tagsCategoryColors = this.props.allExistingTags.map((tag, index) => {
            if(tag.category === "Colors") {
                return (
                    <button
                        key={index}
                        id={tag.id}
                        className="tags"
                        tabIndex="0"
                        type="text"
                        value={tag.name}
                        onClick={this.addSearchingByTag.bind(this)}
                        >{tag.name}
                        <span className="tagColor" style={{backgroundColor: tag.color}}>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    </button>
                )
            }
        })

        let tagsCategoryConsistency = this.props.allExistingTags.map((tag, index) => {
            if(tag.category === "Consistency") {
                return (
                    <button
                        key={index}
                        id={tag.id}
                        className="tags"
                        tabIndex="0"
                        type="text"
                        value={tag.name}
                        onClick={this.addSearchingByTag.bind(this)}
                        >{tag.name}
                    </button>
                )
            }
        })

        let tagsCategorySurfaceAppearance = this.props.allExistingTags.map((tag, index) => {
            if(tag.category === "Surface appearance") {
                return (
                    <button
                        key={index}
                        id={tag.id}
                        className="tags"
                        tabIndex="0"
                        type="text"
                        value={tag.name}
                        onClick={this.addSearchingByTag.bind(this)}
                        >{tag.name}
                    </button>
                )
            }
        })

        let tagsCategoryForm = this.props.allExistingTags.map((tag, index) => {
            if(tag.category === "Form") {
                return (
                    <button
                        key={index}
                        id={tag.id}
                        className="tags"
                        tabIndex="0"
                        type="text"
                        value={tag.name}
                        onClick={this.addSearchingByTag.bind(this)}
                        >{tag.name}
                        <img src={require('../content/tagIcons/' + tag.iconUrl)} className="tagIcon"/>
                    </button>
                )
            }
        })

        let tagsCategoryElevations = this.props.allExistingTags.map((tag, index) => {
            if(tag.category === "Elevations") {
                return (
                    <button
                        key={index}
                        id={tag.id}
                        className="tags"
                        tabIndex="0"
                        type="text"
                        value={tag.name}
                        onClick={this.addSearchingByTag.bind(this)}
                        >{tag.name}
                        <img src={require('../content/tagIcons/' + tag.iconUrl)} className="tagIcon"/>
                    </button>
                )
            }
        })

        let groups = this.props.allExistingGroups.map((grop, index) => (
            <button
                key={index}
                id={grop.id}
                className="groups"
                tabIndex="0"
                type="text"
                value={grop.name}
                onClick={this.addSearchingByGroup.bind(this)}
                >
                {grop.name}
            </button>
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
                                <button
                                    id="searchBtn"
                                    onClick={this.handleSearchBtnClickEvent.bind(this)}
                                    >
                                        <img alt=""/>
                                </button>
                            </td>
                            <td>
                                <Route render={({ history }) => (
                                    <button
                                        id="addSampleBtn"
                                        type='button'
                                        onClick={() => { history.push('/addSample') }}
                                        >Add Sample
                                    </button>
                                )} />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div>
                    {
                        this.state.isGroupsBtnClicked
                        ?
                        <div className="groupsContainer">
                            <button
                                id="groupsTitle"
                                onClick={this.handleGroupsBtnClick.bind(this)}
                                >Groups
                            </button>
                            <br/>
                            {groups}
                        </div>
                        :
                        <button
                            id="groupsBtn"
                            onClick={this.handleGroupsBtnClick.bind(this)}
                            >Groups
                        </button>
                    }
                    {
                        this.state.isTagsBtnClicked
                        ?
                        <div className="tagsConteiner">
                            <button
                                id="tagsTitle"
                                onClick={this.handleTagsBtnClick.bind(this)}
                                >Tags
                            </button>
                            <br/>
                            <h4>Elevations</h4>
                            { tagsCategoryElevations }
                            <hr/>
                            <h4>Form</h4>
                            { tagsCategoryForm }
                            <hr/>
                            <h4>Surface appearance</h4>
                            { tagsCategorySurfaceAppearance }
                            <hr/>
                            <h4>Consistency</h4>
                            { tagsCategoryConsistency }
                            <hr/>
                            <h4>Colors</h4>
                            { tagsCategoryColors }
                        </div>
                        :
                        <button
                            id="tagsBtn"
                            onClick={this.handleTagsBtnClick.bind(this)}
                            >Tags
                        </button>
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
        samples: state.sample.samples,
        allExistingGroups: state.sample.allExistingGroups,
        allExistingTags: state.sample.allExistingTags,
        autocompleteNamesOfSamples: state.sample.autocompleteNamesOfSamples,
        isLoading: state.sample.isLoading,
        error: state.sample.error
    };
  };

const mapDispatchToProps = dispatch => {
    return {
        fetchSamplesByGivenParameters: (params) => dispatch(fetchSamplesByGivenSearchParameters(params)),
        fetchAllNamesOfExistingSamples: () => dispatch(getAllNamesOfExistingSamples()),
        fetchAllExistingTags: () => dispatch(getAllExistingTagsFromServer()),
        fetchAllExistingGroups: () => dispatch(getAllExistingGroupsFromServer())
    };
  };

export default connect(mapStateToProps, mapDispatchToProps)(SampleView)
